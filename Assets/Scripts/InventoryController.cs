using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public Transform itemSlotPrefab;
    public Transform itemSlots;
    public int maxSlot;
    private InventoryData _inventoryData;
    private List<ItemSlotRenderer> _itemSlotRenderers;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _inventoryData = InventoryData.Instance;
        _itemSlotRenderers = new List<ItemSlotRenderer>();
        InitialItemSlot();
        RenderItemSlot();
    }

    private void InitialItemSlot()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            _itemSlotRenderers.Add(Instantiate(itemSlotPrefab, itemSlots).GetComponent<ItemSlotRenderer>());
        }
    }

    private void ClearSlot()
    {
        foreach (var itemSlotRenderer in _itemSlotRenderers)
        {
            itemSlotRenderer.Clear();
        }
    }

    public void RenderItemSlot()
    {
        ClearSlot();
        var renderSlotCount = 0;
        for (var i = 0; i < _inventoryData.items.Count; i++)
        {
            bool hasContainer = false;
            Item item = _inventoryData.items[i];
            if (item.baseItem.isStackable)
            {
                foreach (var itemSlotRenderer in _itemSlotRenderers)
                {
                    var baseItem = itemSlotRenderer.baseItem;
                    if (baseItem == null) continue;
                    if (baseItem.id == item.baseItem.id)
                    {
                        if (itemSlotRenderer.AddQuantity()) hasContainer = true;
                    }
                }
            }

            if (!hasContainer)
            {
                if (renderSlotCount >= _itemSlotRenderers.Count)
                {
                    Debug.Log("Not Enough Space!");
                    break;
                }
                _itemSlotRenderers[renderSlotCount++].Render(item.baseItem);
            }
        }
    }
}