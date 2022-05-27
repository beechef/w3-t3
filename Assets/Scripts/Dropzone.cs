using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler
{
    public DropzoneType type;
    public ItemRenderer itemRenderer;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        ItemRenderer sourceItemRenderer = eventData.pointerDrag.GetComponent<Draggable>().itemRenderer;
        ItemContainer source = sourceItemRenderer.itemContainer;
        ItemContainer target = itemRenderer.itemContainer;
        if (source.baseItem == null) return;
        switch (type)
        {
            case DropzoneType.Inventory:
            {
                if (sourceItemRenderer.dropZone.type != DropzoneType.Inventory)
                {
                    InventoryData.Instance.SwapRequirementToInventory(source.baseItem.type, target);
                    return;
                }
                if (InventoryData.Instance.AddQuantityStackableItem(source, target)) return;
                InventoryData.Instance.SwapInventorySlot(source, target);
                break;
            }
            case DropzoneType.Helm:
            {
                InventoryData.Instance.SwapInventoryToRequirement(source, SlotType.Helm);
                break;
            }
            case DropzoneType.Armor:
            {
                InventoryData.Instance.SwapInventoryToRequirement(source, SlotType.Armor);
                break;
            }
            case DropzoneType.Weapon:
            {
                InventoryData.Instance.SwapInventoryToRequirement(source, SlotType.Weapon);
                break;
            }
            case DropzoneType.Shield:
            {
                InventoryData.Instance.SwapInventoryToRequirement(source, SlotType.Shield);
                break;
            }
            default:
            {
                return;
            }
        }
    }
}

public enum DropzoneType
{
    Inventory,
    Helm,
    Armor,
    Weapon,
    Shield
}