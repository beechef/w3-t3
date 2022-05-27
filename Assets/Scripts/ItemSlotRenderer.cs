using UnityEngine;
using UnityEngine.UI;

public class ItemSlotRenderer : ItemRenderer
{
    [HideInInspector]
    public int quantity;
    public Text textQuantity;
    public GameObject removeButton;
    
    public override void Render(ItemContainer itemContainer)
    {
        base.Render(itemContainer);
        textQuantity.enabled = true;
        quantity = this.itemContainer.Quantity;
        textQuantity.text = quantity.ToString();
        removeButton.SetActive(true);
    }

    public override void Clear(int slot)
    {
        base.Clear(slot);
        textQuantity.enabled = false;
        quantity = 1;
        textQuantity.text = quantity.ToString();
        removeButton.SetActive(false);
    }
}