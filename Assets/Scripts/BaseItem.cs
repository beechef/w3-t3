using UnityEngine;

[CreateAssetMenu(fileName = "New Base Item", menuName = "Item/Base Item")]
public class BaseItem : ScriptableObject
{
    public int index;
    public new string name;
    public Sprite icon;
}