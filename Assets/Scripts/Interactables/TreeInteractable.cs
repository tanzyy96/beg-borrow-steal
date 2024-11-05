using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractable : Interactable
{
    public int health = 3; // Number of hits to cut down
    private Animator animator;

    private float damageTimer;
    private float damageInterval = 0.45f; // 0.45s because full animation is 0.5s and we leave a bit of buffer time

    private void Awake()
    {
        animator = transform.Find("TreeCuttingEffect").GetComponent<Animator>();
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
            ChopDown();
            player.AnimateActionBool("isCutting", false);
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

    void ChopDown()
    {
        Debug.Log("Chopping down tree");
        // Play animation
        // Play sound
        // Drop wood
        // Destroy tree
        Destroy(gameObject);
    }
}
