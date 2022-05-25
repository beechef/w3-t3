using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotRenderer : MonoBehaviour
{
    public BaseItem baseItem;
    public Image icon;
    public Text quantity;
    
    public void Render(BaseItem baseItem)
    {
        this.baseItem = baseItem;
        icon.enabled = true;
        quantity.enabled = true;
        quantity.text = "1";
        icon.sprite = this.baseItem.icon;
    }
    public void Clear()
    {
        baseItem = null;
        icon.enabled = false;
        quantity.enabled = false;
        quantity.text = "1";
    }
}
