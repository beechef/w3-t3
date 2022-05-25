using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Base Item List", menuName = "Item/BaseItemList")]
public class BaseItemList : ScriptableObject
{
    public List<BaseItem> baseItems;
}