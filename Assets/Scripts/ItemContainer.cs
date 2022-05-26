using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemContainer
{
    public int id;
    public int slot;
    [HideInInspector] public int baseItemId = -1;
    public BaseItem baseItem;
    public List<Item> items;

    public int Quantity
    {
        get
        {
            if (items == null || items.Count == 0) return 1;
            return items.Count;
        }
    }
}

[System.Serializable]
public class Item
{
    public int id;
    public int baseItemId;
}