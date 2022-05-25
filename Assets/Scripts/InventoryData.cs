using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Unity.Collections;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public static InventoryData Instance;
    public Item item;
    public bool AddItem;
    public bool SaveData;
    public List<Item> items;
    public BaseItemList baseItemList;
    private const string Inventory = "INVENTORY";

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
            InventoryController.Instance.RenderItemSlot();
        }
    }

    private void Load()
    {
        items = JsonConvert.DeserializeObject<List<Item>>(PlayerPrefs.GetString(Inventory)) ??
                new List<Item>();
        foreach (var baseItem in baseItemList.baseItems)
        {
            foreach (var item in items)
            {
                if (item.baseItemId == baseItem.id)
                {
                    item.baseItem = baseItem;
                }
            }
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString(Inventory, JsonConvert.SerializeObject((from item in items select new Item()
        {
            id = item.id,
            baseItemId = item.baseItem.id
        }).ToList()));
    }
    
}