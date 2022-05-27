using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RequirementRenderer : MonoBehaviour
{
    public ItemContainer itemContainer;
    public Image icon;
    private BaseItem _baseItem;

    public void Render(ItemContainer itemContainer)
    {
        this.itemContainer = itemContainer;

        _baseItem = this.itemContainer.baseItem;
        icon.enabled = true;
        icon.sprite = _baseItem.icon;
        icon.color = new Color(1, 1, 1, 1);
    }

    public void Clear(int slot)
    {
        itemContainer = new ItemContainer()
        {
            slot = slot
        };
        _baseItem = null;
        // icon.enabled = false;
        icon.color = new Color(1, 1, 1, 0);
    }
}