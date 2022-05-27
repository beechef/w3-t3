using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

public class ItemRowRenderer : EnhancedScrollerCellView
{
    private const int ROW = 6;
    public ItemRenderer[] itemRenderers = new ItemRenderer[ROW];

    public void Render(int baseIndex)
    {
        for (int i = 0; i < ROW; i++)
        {
            int index = baseIndex + i;
            ItemRenderer itemRenderer = itemRenderers[i];
            ItemContainer itemContainer = InventoryData.Instance.GetDataBySlot(index);
            if (itemContainer == null)
            {
                itemRenderer.Clear(index);
            }
            else
            {
                itemRenderer.Render(itemContainer);
            }
        }
    }
}