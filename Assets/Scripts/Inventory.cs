using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName; // Null if empty
        public int quantity;
        public int maxQuantity;
        public Sprite icon;

        public Slot()
        {
            itemName = "";
            quantity = 0;
            maxQuantity = 99;
        }

        public Slot(string itemName, int quantity, int maxQuantity)
        {
            this.itemName = itemName;
            this.quantity = quantity;
            this.maxQuantity = maxQuantity;
        }

        public bool CanAddItems(int quantity = 1)
        {
            return this.quantity + quantity <= maxQuantity;
        }

        public void AddItems(Item item, int quantity = 1)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            this.quantity += quantity;

            // If quantity exceeds max, leak resources and set to max
            if (this.quantity > maxQuantity)
            {
                Debug.LogError("Quantity exceeds max quantity for slot! Should check CanAddItems() first.");
                this.quantity = maxQuantity;
            }
        }

        public void RemoveItem()
        {
            this.quantity--;
            if (this.quantity <= 0)
            {
                this.itemName = "";
                this.icon = null;
                this.quantity = 0;
            }
        }
    }

    public List<Slot> slots = new List<Slot>();
    public const int MaxSlots = 20;

    public Inventory(int numSlots = MaxSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot emptySlot = new Slot();
            slots.Add(emptySlot);
        }
    }

    public void Add(Item item, int quantity = 1)
    {
        Slot slot = slots.Find(s => s.itemName == item.data.itemName);

        if (slot != null && slot.CanAddItems(quantity))
        {
            slot.AddItems(item, quantity);
        }
        // If slot exists but can't add items, add to another slot
        // TODO: handle hitting slots max quantity
        else
        {
            Slot emptySlot = slots.Find(s => s.itemName == "");
            if (emptySlot != null)
            {
                emptySlot.AddItems(item, quantity);
            }
        }
        // TODO: handle case where no more slots and no existing slot for this type
        // e.g. don't pick up item and show warning to player
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
}
