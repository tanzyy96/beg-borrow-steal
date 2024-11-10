using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodItem : Item
{
    private void Start()
    {
        itemName = "Wood";

        // Assign the icon from the game object's sprite renderer
        icon = GetComponent<SpriteRenderer>().sprite;
    }
}
