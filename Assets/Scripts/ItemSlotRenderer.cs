using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSlotRenderer : MonoBehaviour
{
    public BaseItem baseItem;
    public Image icon;
    public int quantity;
    public Text textQuantity;
    
    public void Render(BaseItem baseItem)
    {
        this.baseItem = baseItem;
        icon.enabled = true;
        textQuantity.enabled = true;
        icon.sprite = this.baseItem.icon;
        quantity = 1;
        textQuantity.text = quantity.ToString();
    }
    public void Clear()
    {
        baseItem = null;
        icon.enabled = false;
        textQuantity.enabled = false;
        quantity = 1;
        textQuantity.text = quantity.ToString();
    }

    public bool AddQuantity()
    {
        if (quantity + 1 < baseItem.maxSize && baseItem.isStackable)
        {
            quantity++;
            textQuantity.text = quantity.ToString();
            return true;
        }

        return false;
    }
}
