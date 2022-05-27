using UnityEngine;

public static class CharacterData
{
    public static Stats Stats = new Stats();
    private static ItemContainer[] _requirements = InventoryData.Instance.requirementItems;

    public static void CalculateStats()
    {
        Stats = new Stats();
        foreach (var item in _requirements)
        {
            if (item.baseItem == null) continue;
            Stats += item.baseItem.stats;
        }
    }
}
