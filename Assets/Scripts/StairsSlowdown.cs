using UnityEngine;

public class StairSlowdown : MonoBehaviour
{
    public float slowMultiplier = 0.5f; // Percentage to reduce speed by on stairs
    private float originalSpeed;        // Store the original speed temporarily
    private Movement playerMovement; // Reference to player's movement script

    private void Start()
    {
        // Get the player's movement script (adjust name as needed)
        playerMovement = GetComponent<Movement>();

        if (playerMovement != null)
        {
            originalSpeed = playerMovement.speed; // Assume 'speed' is the public property in PlayerMovement
        }
        else
        {
            Debug.LogError("PlayerMovement component not found on the player!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Add a tag to the stairs object
        if (other.CompareTag("Stairs") && playerMovement != null)
        {
            playerMovement.speed *= slowMultiplier; // Reduce speed by multiplier
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stairs") && playerMovement != null)
        {
            playerMovement.speed = originalSpeed; // Restore original speed
        }
    }
}
