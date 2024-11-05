using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hold mapping of CollectableType to CollectablePrefab
public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> itemMap = new Dictionary<string, Item>();

    void Awake()
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }

    }

    void AddItem(Item item)
    {
        if (!itemMap.ContainsKey(item.data.name))
        {
            itemMap.Add(item.data.itemName, item);
        }

    }

    public Item GetItemByName(string name)
    {
        if (itemMap.ContainsKey(name))
        {
            return itemMap[name];
        }
        return null;
    }

}
