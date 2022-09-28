using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonData
{
    public bool hasSawTrail = false;
    public int curStationIndex = 0;
    public List<CraftedEnviroment> craftedEnviroments = new List<CraftedEnviroment>();
    public List<InventoryItemData> inventory = new List<InventoryItemData>();
    public List<string> openBox = new List<string>();
    public List<GoogleSheetData> sheetData = new List<GoogleSheetData>();
}

[Serializable]
public class CraftedEnviroment
{
    public CraftedEnviroment(GameObject obj)
    {
        position = obj.transform.position;
        name = obj.name;
    }
    public Vector3 position;
    public string name;
}

[Serializable]
public class InventoryItemData
{
    public ItemDataSO itemData;
    public int count;
}

[Serializable]
public class GoogleSheetData
{
    public List<string> cell = new List<string>();
}