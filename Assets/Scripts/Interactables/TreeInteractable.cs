using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractable : Interactable
{
    public int health = 3; // Number of hits to cut down
    private Animator animator;
    public GameObject woodPrefab;
    public GameObject stumpPrefab;

    private float damageTimer;
    private float damageInterval = 0.45f; // 0.45s because full animation is 0.5s and we leave a bit of buffer time
    private int numWoodToSpawn = 3;

    private void Awake()
    {
        animator = transform.GetComponent<Animator>();
        mustFaceToInteract = true;
    }

    public override void Interact(Player player)
    {
        Debug.Log("Tree health: " + health);

        if (animator != null)
        {
            animator.SetBool("isCutting", true);
            player.AnimateActionBool("isCutting", true);

            // If player is facing right, flip the tree cutting effect
            if (player.isFacing(Side.Right))
            {
                animator.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                animator.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // Damage over time
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageInterval)
        {
            health -= player.damage;
            damageTimer = 0;
        }

        if (health <= 0)
        {
            ChopDown(player);
            player.AnimateActionBool("isCutting", false);
        }
    }

    private void SpawnWood(Player player)
    {
        var yOffset = -0.5f; // not very dynamic but fk it
        for (int i = 0; i < numWoodToSpawn; i++)
        {
            Vector3 randomOffset;
            // Random offset for natural spread
            // maybe want to spawn the opposite side of the player?
            // Can consider Random.insideUnitCircle maybe
            if (player.isFacing(Side.Right))
            {
                randomOffset = new Vector3(Random.Range(0.2f, 0.5f), yOffset + Random.Range(-0.2f, 0.2f), 0);
            }
            else
            {
                randomOffset = new Vector3(Random.Range(-0.5f, -0.2f), yOffset + Random.Range(-0.2f, 0.2f), 0);
            }
            yOffset += 0.5f;

            // Spawn the wood object with the offset
            GameObject wood = Instantiate(woodPrefab, transform.position + randomOffset, Quaternion.identity);

            // Play the spawn effect
            // Probably better to interact with WoodInteractable and let it handle the spawn effect
            Animator woodAnimator = wood.transform.GetComponent<Animator>();
            if (woodAnimator != null)
            {
                woodAnimator.SetTrigger("spawn");
            }

            Rigidbody2D rb = wood.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(randomOffset * 2f, ForceMode2D.Impulse);
            }
        }
    }

    public override void StopInteracting(Player player)
    {
        if (animator != null)
        {
            animator.SetBool("isCutting", false);
            player.AnimateActionBool("isCutting", false);
            damageTimer = 0;
        }
    }

    void SpawnTrunk()
    {
        Instantiate(stumpPrefab, transform.position, Quaternion.identity);
    }

    void ChopDown(Player player)
    {
        // Play animation
        // Play sound
        // Drop wood
        SpawnWood(player);
        // Destroy tree
        Destroy(gameObject);
        // Spawn stump
        SpawnTrunk();
    }
}
