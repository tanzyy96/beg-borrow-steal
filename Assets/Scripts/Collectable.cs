using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    None,
    Gold,
    Wood
}

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for Player component
        Player player = other.GetComponent<Player>();
        if (player)
        {
            Item item = GetComponent<Item>();
            player.inventory.Add(item);
            // Destroy the collectable object
            Destroy(gameObject);
        }
    }
}
