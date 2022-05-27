using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToolTipRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerDownHandler
{
    private GameObject _toolTip;
    private ItemToolTip _itemToolTip;
    private BaseItem _baseItem;
    public ItemRenderer itemRenderer;
    private void Awake()
    {
        _toolTip = GameObject.FindGameObjectWithTag("ToolTip");
        _itemToolTip = _toolTip.GetComponent<ItemToolTip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _baseItem = itemRenderer.itemContainer.baseItem;
        if (_baseItem == null) return;
        _toolTip.SetActive(true);
        _itemToolTip.Render(_baseItem);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (_baseItem == null) return;
        _toolTip.transform.position = eventData.position;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_baseItem == null) return;
        _toolTip.SetActive(false);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_baseItem == null) return;
        _toolTip.SetActive(false);
    }
}
