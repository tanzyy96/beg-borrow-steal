using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Left,
    Right
}

public class Player : MonoBehaviour
{
    public int damage = 1;
    public float interactionRange = 0.7f;

    public Inventory inventory;
    public Animator animator; // Can think about whether want to split this into its own file

    private Interactable currentInteractable;

    public void Awake()
    {
        inventory = new Inventory();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TryToInteract();
        }
        else
        {
            StopInteracting();
        }
    }

    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = Random.insideUnitCircle * 1.25f;

        // Create item
        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        // Add force to item
        droppedItem.rb.AddForce(spawnOffset * 0.2f, ForceMode2D.Impulse);

    }

    // Try to interact with interactables in range
    // This is fired every frame when the player is holding down the space bar
    public void TryToInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        foreach (Collider2D collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null && isFacing(interactable.transform.position))
            {
                interactable.Interact(this);
                currentInteractable = interactable;
                return; // Stop after first interaction
            }
        }
    }

    public bool isFacing(Side side)
    {
        if (side == Side.Left && transform.localScale.x < 0)
        {
            return true;
        }
        else if (side == Side.Right && transform.localScale.x > 0)
        {
            return true;
        }
        return false;
    }

    // Player is facing the target position's side of the screen
    public bool isFacing(Vector3 targetPosition)
    {
        // If localscale.x is positive, player is facing right
        if (transform.localScale.x > 0 && targetPosition.x > transform.position.x)
        {
            return true;
        }
        // If localscale.x is negative, player is facing left
        else if (transform.localScale.x < 0 && targetPosition.x < transform.position.x)
        {
            return true;
        }
        return false;
    }

    public void StopInteracting()
    {
        if (currentInteractable != null)
        {
            currentInteractable.StopInteracting(this);
            currentInteractable = null;
        }
    }

    public void AnimateActionBool(string animationParam, bool value)
    {
        if (animator != null)
        {
            animator.SetBool(animationParam, value);
        }
    }

    public void AnimateActionTrigger(string animationParam)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationParam);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
