using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1); // make visible?
            // Scale up the icon by .2x
            itemIcon.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

            quantityText.text = slot.quantity.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0); // make invisible
        quantityText.text = "";
        // Reset the icon scale
        itemIcon.rectTransform.localScale = new Vector3(1, 1, 1);
    }

}
