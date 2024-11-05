using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<SlotUI> slots = new List<SlotUI>();

    void Start()
    {
        inventoryPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

    }

    public void ToggleInventory()
    {
        SyncInventory();
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    void SyncInventory()
    {
        if (slots.Count != player.inventory.slots.Count) return; // something went wrong lol

        for (int i = 0; i < player.inventory.slots.Count; i++)
        {
            if (player.inventory.slots[i].itemName != "")
            {
                slots[i].SetItem(player.inventory.slots[i]);
            }
            else
            {
                slots[i].SetEmpty();
            }
        }
    }

    public void Remove(int slotIndex)
    {
        Item itemToRemove = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotIndex].itemName);
        if (itemToRemove != null)
        {
            Debug.Log("Removing item");
            player.DropItem(itemToRemove);
            player.inventory.slots[slotIndex].RemoveItem();
            SyncInventory();
        }
    }
}
