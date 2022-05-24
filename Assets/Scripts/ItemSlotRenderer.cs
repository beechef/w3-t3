using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSlotRenderer : MonoBehaviour
{
    public BaseItem baseItem;
    public Image icon;
    public Text quantity;
    void Start()
    {
        icon.enabled = true;
        quantity.enabled = true;
        icon.sprite = baseItem.icon;
    }
}
