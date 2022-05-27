using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

public class ItemRenderer : MonoBehaviour 
{
    public ItemContainer itemContainer;
    public Dropzone dropZone;
    public Image icon;
    protected BaseItem _baseItem;

    public virtual void Render(ItemContainer itemContainer)
    {
        if (itemContainer.baseItem == null) return;
        this.itemContainer = itemContainer;
        _baseItem = this.itemContainer.baseItem;
        icon.enabled = true;
        icon.sprite = _baseItem.icon;
        icon.color = new Color(1, 1, 1, 1);
    }

    public virtual void Clear(int slot)
    {
        itemContainer = new ItemContainer()
        {
            slot = slot
        };
        _baseItem = null;
        icon.color = new Color(1, 1, 1, 0);
    }
}

