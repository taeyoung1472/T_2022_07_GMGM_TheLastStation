using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/CraftData")]
public class CraftDataSO : ScriptableObject
{
    public ItemDataSO targetItem;
    public CraftElement[] craftElements;
}

[System.Serializable]
public class CraftElement
{
    public ItemDataSO data;
    public int amount;
}