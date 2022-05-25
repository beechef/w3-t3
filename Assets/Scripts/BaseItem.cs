﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Base Item", menuName = "Item/Base Item")]
[System.Serializable]
public class BaseItem : ScriptableObject
{
    [HideInInspector] public int id;
    public new string name;
    public bool isStackable;
    public int maxSize;
    public Sprite icon;
    public Stat stat;
}