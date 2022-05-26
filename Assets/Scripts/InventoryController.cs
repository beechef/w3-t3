using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public Transform itemSlotPrefab;
    public Transform itemSlots;
    public int maxSlot;
    public ItemRenderer helmSlot;
    public ItemRenderer armorSlot;
    public ItemRenderer weaponSlot;
    public ItemRenderer shieldSlot;
    private InventoryData _inventoryData;
    private List<ItemSlotRenderer> _itemSlotRenderers;
    private ItemRenderer[] _requirements;

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
        _requirements = new ItemRenderer[Enum.GetNames(typeof(SlotType)).Length];
        InitialSlot();
        RenderSlot();
    }

    private void InitialSlot()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            _itemSlotRenderers.Add(Instantiate(itemSlotPrefab, itemSlots).GetComponent<ItemSlotRenderer>());
        }

        _requirements[Convert.ToInt32(SlotType.Helm)] = helmSlot;
        _requirements[Convert.ToInt32(SlotType.Armor)] = armorSlot;
        _requirements[Convert.ToInt32(SlotType.Weapon)] = weaponSlot;
        _requirements[Convert.ToInt32(SlotType.Shield)] = shieldSlot;
    }

    private void ClearSlot()
    {
        for (int i = 0; i < _itemSlotRenderers.Count; i++)
        {
            _itemSlotRenderers[i].Clear(i);
        }

        for (int i = 0; i < _requirements.Length; i++)
        {
            if (_requirements[i] != null)
            {
                _requirements[i].Clear(i);
            }
        }
    }

    public void RenderSlot()
    {
        ClearSlot();
        for (var i = 0; i < _inventoryData.inventoryItems.Count; i++)
        {
            ItemContainer itemContainer = _inventoryData.inventoryItems[i];

            if (itemContainer.slot >= maxSlot)
            {
                Debug.Log("Not Enough Space!");
                break;
            }

            _itemSlotRenderers[itemContainer.slot].Render(itemContainer);
        }
        for (int i = 0; i < _requirements.Length; i++)
        {
            if (_requirements[i] != null)
            {
                _requirements[i].Render(_inventoryData.requirementItems[i]);
            }
        }
    }
}