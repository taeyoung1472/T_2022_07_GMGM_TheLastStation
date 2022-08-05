using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class JsonData
{
    public bool hasSawTrail = false;
    public int curStationIndex = 0;
    public List<InventoryItemData> inventory = new List<InventoryItemData>();
    public List<string> openBox = new List<string>();
}

[Serializable]
public class InventoryItemData
{
    public ItemDataSO itemData;
    public int count;
}