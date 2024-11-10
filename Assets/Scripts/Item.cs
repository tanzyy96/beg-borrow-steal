using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item : Interactable
{
    // public ItemData data;
    public string itemName;
    public Sprite icon;

    public Item()
    {
        this.mustFaceToInteract = false;
    }

    public override void Interact(Player player)
    {
        // Pick up item
        player.inventory.Add(this);
        gameObject.SetActive(false); // Cannot destroy cuz inventory is using this reference
    }

    public override void StopInteracting(Player player)
    {
        // Do nothing
    }
}
