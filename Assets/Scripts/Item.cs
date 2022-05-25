using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    [HideInInspector]
    public int baseItemId;
    public BaseItem baseItem;
}

public class ItemContainer : Item
{
    public List<Item> items;
    public int Quantity
    {
        get
        {
            return items.Count;
        }
    }
}