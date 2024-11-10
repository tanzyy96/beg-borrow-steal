using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void SetItem(Item item, int quantity)
    {
        if (item != null)
        {
            itemIcon.sprite = item.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = quantity.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";

    }

}
