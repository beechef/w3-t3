using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;

public class ScrollerController : MonoBehaviour, IEnhancedScrollerDelegate 
{
    private List<ScrollerData> _data;

    public EnhancedScroller myScroller;
    public ItemSlotRenderer animalCellViewPrefab;

	void Start () 
    {
        _data = new List<ScrollerData>();

        _data.Add(new ScrollerData() { animalName = "Lion" });
        _data.Add(new ScrollerData() { animalName = "Bear" });
        _data.Add(new ScrollerData() { animalName = "Eagle" });
        _data.Add(new ScrollerData() { animalName = "Dolphin" });
        _data.Add(new ScrollerData() { animalName = "Ant" });
        _data.Add(new ScrollerData() { animalName = "Cat" });
        _data.Add(new ScrollerData() { animalName = "Sparrow" });
        _data.Add(new ScrollerData() { animalName = "Dog" });
        _data.Add(new ScrollerData() { animalName = "Spider" });
        _data.Add(new ScrollerData() { animalName = "Elephant" });
        _data.Add(new ScrollerData() { animalName = "Falcon" });
        _data.Add(new ScrollerData() { animalName = "Mouse" });
        Debug.Log("Start");
        myScroller.Delegate = this;
        myScroller.ReloadData();
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        Debug.Log("Number Cell");

        return 1;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 100f;
    }

    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        // // ItemSlotRenderer cellView = scroller.GetCellView(animalCellViewPrefab) as ItemSlotRenderer;
        // Debug.Log("abc");
        // // cellView.SetData(_data[dataIndex]);
        // ItemContainer itemContainer = InventoryData.Instance.GetDataBySlot(dataIndex);
        // if (itemContainer == null)
        // {
        //     // cellView.Clear(dataIndex);
        //     // return cellView;
        // }
        // // cellView.Render(itemContainer);

        return null;
    }

}
