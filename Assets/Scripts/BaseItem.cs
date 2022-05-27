using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Base Item", menuName = "Item/Base Item")]
[System.Serializable]
public class BaseItem : ScriptableObject
{
    public int id;
    public new string name;
    public SlotType type;
    public bool isStackable;
    public int maxSize;
    public Sprite icon;
    [FormerlySerializedAs("stat")] public Stats stats;
}

public enum SlotType
{
    None,
    Helm,
    Armor,
    Weapon,
    Shield
}