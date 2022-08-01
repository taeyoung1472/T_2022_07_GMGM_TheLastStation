using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTable : Enviroment
{
    [SerializeField] private CraftDataSO[] craftDatas;
    [SerializeField] private string tableName;
    public void Act()
    {
        UIManager.Instance.ActiveCraftTable();
        UIManager.Instance.SetCraftTable(tableName, craftDatas);
    }
}
