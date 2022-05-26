using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public ItemRenderer itemRenderer;
    private int _slot;
    private Transform _parent;
    private Vector3 _position;
    private Vector2 _anchor;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _parent = transform.parent;
        _slot = transform.GetSiblingIndex();
        _position = _rectTransform.position;
        _anchor = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Inventory").transform);
        _canvasGroup.alpha = 0.7f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }
    

    private void RefreshLayout()
    {
        transform.SetParent(_parent);
        transform.SetSiblingIndex(_slot);
        _rectTransform.anchoredPosition = _anchor;
        _rectTransform.position = _position;
        _rectTransform.localPosition = Vector3.zero;
        // Debug.Log(_rectTransform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true;
        RefreshLayout();
    }
    
}
