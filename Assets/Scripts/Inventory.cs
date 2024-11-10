using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public Item item;
        public int quantity;

        public Slot()
        {
            this.item = null;
            quantity = 0;
        }

        public Slot(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }

        public void AddItems(Item item, int quantity = 1)
        {
            if (this.item == null)
            {
                this.item = item;
            }
            if (this.item.itemName != item.itemName)
            {
                Debug.LogError("Item name does not match slot item name! Should check CanAddItems() first.");
                return;
            }

            this.quantity += quantity;
        }

        public void RemoveItem(int quantity = 1)
        {
            this.quantity -= 1;
            if (this.quantity <= 0)
            {
                this.ClearSlot();
            }
        }

        public void ClearSlot()
        {
            this.item = null;
            this.quantity = 0;
        }
    }

    public List<Slot> slots = new List<Slot>();
    public int MaxSlots = 5;

    public void Add(Item item, int quantity = 1)
    {
        Slot slot = slots.Find(s => s.item.itemName == item.itemName);

        if (slot != null)
        {
            slot.AddItems(item, quantity);
        }
        else
        {
            Slot newSlot = new Slot(item, quantity);
            slots.Add(newSlot);
        }
    }

    public bool HasItems(string itemName, int quantity)
    {
        Slot slot = slots.Find(s => s.item.itemName == itemName);

        return (slot != null && slot.quantity >= quantity);
    }

    public void Remove(string itemName, int quantity = 1)
    {
        Slot slot = slots.Find(s => s.item.itemName == itemName);

        if (slot != null && slot.quantity >= quantity)
        {
            slot.RemoveItem(quantity);
        }
        else
        {
            Debug.LogError("Item not found in inventory or quantity is less than requested.");
        }
    }
}
