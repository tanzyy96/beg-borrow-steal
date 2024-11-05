using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton class to manage game state
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Some of these are just here to expose their functions to other scripts
    public Inventory playerInventory;
    public InventoryUI inventoryUI;
    public ItemManager itemManager;

    void Awake()
    {
        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        playerInventory = new Inventory();
        inventoryUI = FindObjectOfType<InventoryUI>();
        itemManager = FindObjectOfType<ItemManager>();
    }

}
