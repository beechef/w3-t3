using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RemoveItemInventory : MonoBehaviour
{
    public ItemRenderer itemRenderer;

    public void RemoveItem()
    {
        InventoryData.Instance.RemoveItemFromInventory(itemRenderer.itemContainer);
    }
}
