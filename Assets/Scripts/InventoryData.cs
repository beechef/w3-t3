using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class InventoryData : MonoBehaviour
{
    private const int MAX_ITEM = 9999;
    private const string Inventory = "INVENTORY";
    private const string Requirement = "REQUIREMENT";

    public static InventoryData Instance;
    public BaseItem newBaseItem;
    public bool AddNewItem;
    public bool SaveData;
    public List<ItemContainer> inventoryItems;
    public ItemContainer[] requirementItems;
    public BaseItemList baseItemList;


    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
        Load();
    }

    private void Update()
    {
        if (SaveData)
        {
            SaveData = false;
            Save();
        }

        if (AddNewItem)
        {
            AddNewItem = false;
            AddItem();
            Save();
        }
    }

    private void Load()
    {
        inventoryItems = JsonConvert.DeserializeObject<List<ItemContainer>>(PlayerPrefs.GetString(Inventory)) ??
                         new List<ItemContainer>();
        foreach (var baseItem in baseItemList.baseItems)
        {
            foreach (var item in inventoryItems)
            {
                if (item.baseItemId == baseItem.id)
                {
                    item.baseItem = baseItem;
                }
            }
        }

        requirementItems = JsonConvert.DeserializeObject<ItemContainer[]>(PlayerPrefs.GetString(Requirement));
        if (requirementItems.Length == 0 || requirementItems == null)
        {
            requirementItems = new ItemContainer[Enum.GetNames(typeof(SlotType)).Length];
        }

        foreach (var baseItem in baseItemList.baseItems)
        {
            foreach (var item in requirementItems)
            {
                if (item?.baseItemId == baseItem.id)
                {
                    item.baseItem = baseItem;
                }
            }
        }
    }


    private void Save()
    {
        PlayerPrefs.SetString(Inventory, JsonConvert.SerializeObject((from item in inventoryItems
            select new ItemContainer()
            {
                slot = item.slot,
                id = item.id,
                baseItemId = item.baseItem == null ? -1 : item.baseItem.id,
                items = item.items
            }).ToList()));
        PlayerPrefs.SetString(Requirement, JsonConvert.SerializeObject(from item in requirementItems
            select new ItemContainer()
            {
                id = item.id,
                baseItemId = item.baseItem == null ? -1 : item.baseItem.id,
                items = item.items ?? new List<Item>()
            }));
        InventoryController.Instance.RenderSlot();
    }

    private bool HasExistSerial(int serial)
    {
        foreach (var item in inventoryItems)
        {
            if (serial == item.id) return true;
            if (item.items == null) continue;
            foreach (var childItem in item.items)
            {
                if (childItem.id == serial) return true;
            }
        }

        return false;
    }

    private int GenerateSerial()
    {
        int serial = Random.Range(0, MAX_ITEM);
        while (HasExistSerial(serial))
        {
            serial = Random.Range(0, MAX_ITEM);
        }

        return serial;
    }

    private ItemContainer FindStackableItem(int baseItemId)
    {
        foreach (var item in inventoryItems)
        {
            if (item.baseItem.id == baseItemId
                && item.baseItem.isStackable
                && item.baseItem.maxSize >= item.Quantity + 1)
            {
                return item;
            }
        }

        return null;
    }

    private int GetSlot()
    {
        int index = -1;
        SortedList<int, int> slots = new SortedList<int, int>();
        foreach (var item in inventoryItems)
        {
            slots.Add(item.slot, item.slot);
        }

        if (!slots.ContainsKey(0)) return 0;

        foreach (var slot in slots)
        {
            if (!slots.ContainsKey(slot.Key + 1)) return slot.Key + 1;
        }

        return index;
    }

    private void AddItem()
    {
        if (newBaseItem == null)
        {
            Debug.Log("Invalid Base Item!");
            return;
        }

        ItemContainer itemContainer;
        if (newBaseItem.isStackable)
        {
            itemContainer = FindStackableItem(newBaseItem.id);
            if (itemContainer != null)
            {
                itemContainer.items.Add(new() {id = GenerateSerial(), baseItemId = itemContainer.baseItem.id});
                return;
            }
        }

        itemContainer = new ItemContainer
        {
            slot = GetSlot(),
            id = GenerateSerial(),
            baseItem = newBaseItem
        };
        if (itemContainer.baseItem.isStackable)
        {
            itemContainer.items = new List<Item>()
            {
                new()
                {
                    id = GenerateSerial(),
                    baseItemId = itemContainer.baseItemId
                }
            };
        }

        inventoryItems.Add(itemContainer);
    }

    public void SwapInventorySlot(ItemContainer source, ItemContainer target)
    {
        int tmp = source.slot;
        source.slot = target.slot;
        target.slot = tmp;
        Save();
    }

    public bool AddQuantityStackableItem(ItemContainer source, ItemContainer target)
    {
        if (target?.baseItem != null
            && source.baseItem.isStackable
            && source.baseItem.id == target.baseItem?.id
            && target.Quantity + source.Quantity <= source.baseItem.maxSize)
        {
            target.items.AddRange(source.items);
            inventoryItems.Remove(source);
            Save();
            return true;
        }

        return false;
    }

    public void SwapInventoryToRequirement(ItemContainer source, SlotType type)
    {
        if (source.baseItem.type != type) return;
        int indexSource = inventoryItems.IndexOf(source);
        int indexTarget = Convert.ToInt32(type);
        ItemContainer target = requirementItems[indexTarget];
        target.slot = source.slot;
        requirementItems[indexTarget] = source;
        if (target.baseItem == null)
        {
            inventoryItems.RemoveAt(indexSource);
            Save();
            return;
        }

        inventoryItems[indexSource] = target;
        Save();
    }

    public void SwapRequirementToInventory(SlotType type, ItemContainer target)
    {
        if (target?.baseItem != null && target.baseItem.type != type) return;
        int indexTarget = inventoryItems.IndexOf(target);
        if (indexTarget == -1)
        {
            inventoryItems.Add(new ItemContainer());
            indexTarget = inventoryItems.Count - 1;
        }

        int indexSource = Convert.ToInt32(type);
        ItemContainer source = requirementItems[indexSource];
        
        source.slot = target.slot;
        inventoryItems[indexTarget] = source;

        if (target.baseItem == null)
        {
            requirementItems[indexSource] = null;
        }

        requirementItems[indexSource] = target;
        Save();
    }
}