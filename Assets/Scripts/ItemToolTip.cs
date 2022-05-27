using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    public new Text name;
    public Text type;
    public Text stats;
    public void Render(BaseItem baseItem)
    {
        name.text = baseItem.name;
        type.text = Enum.GetName(typeof(SlotType), baseItem.type);
        stats.text = baseItem.stats.ToString();
    }
}
