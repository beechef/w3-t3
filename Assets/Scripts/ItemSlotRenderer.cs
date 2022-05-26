using UnityEngine.UI;

public class ItemSlotRenderer : ItemRenderer
{
    public int quantity;
    public Text textQuantity;

    public override void Render(ItemContainer itemContainer)
    {
        base.Render(itemContainer);
        textQuantity.enabled = true;
        quantity = this.itemContainer.Quantity;
        textQuantity.text = quantity.ToString();
    }

    public override void Clear(int slot)
    {
        base.Clear(slot);
        textQuantity.enabled = false;
        quantity = 1;
        textQuantity.text = quantity.ToString();
    }
}