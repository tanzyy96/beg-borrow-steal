using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Player player;
    public List<SlotUI> slots = new List<SlotUI>();

    public GameObject slotsGrid;
    public GameObject slotPrefab;

    void Start()
    {
        for (int i = 0; i < player.inventory.MaxSlots; i++)
        {
            SlotUI slotUI = Instantiate(slotPrefab, slotsGrid.transform).GetComponent<SlotUI>();
            slots.Add(slotUI);
            slots[i].SetEmpty();
        }
    }

    void Update()
    {
        SyncInventory();
    }

    void SyncInventory()
    {
        // Clear all slots
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].SetEmpty();
        }

        // Add items to slots
        for (int i = 0; i < player.inventory.slots.Count; i++)
        {
            if (player.inventory.slots[i].item != null)
            {
                if (i < slots.Count)
                {
                    slots[i].SetItem(player.inventory.slots[i].item, player.inventory.slots[i].quantity);
                }
            }
        }
    }

    public void Remove(int slotIndex)
    {
        // Item itemToRemove = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotIndex].itemName);
        // if (itemToRemove != null)
        // {
        //     Debug.Log("Removing item");
        //     // player.DropItem(itemToRemove);
        //     player.inventory.slots[slotIndex].RemoveItem();
        //     SyncInventory();
        // }
    }
}
