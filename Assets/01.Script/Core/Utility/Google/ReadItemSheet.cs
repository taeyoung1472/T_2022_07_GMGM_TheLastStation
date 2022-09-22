using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Data;

public class ReadItemSheet : MonoBehaviour
{
    [SerializeField] private ItemDataSO[] datas;

    [ContextMenu("SetIndex")]
    public void InitID()
    {
        foreach (var dt in datas)
        {
            dt.SetIndex();
        }
    }

    [ContextMenu("Push Data")]
    public void Init()
    {
        Dictionary<int, ItemDataSO> dataDic = new Dictionary<int, ItemDataSO>();
        
        foreach (ItemDataSO data in datas)
        {
            dataDic.Add(data.itemId, data);
        }

        foreach (GoogleSheetData data in JsonManager.Data.sheetData)
        {
            int name = Utility.ParseStringToInt(data.cell[(int)ItemIndex.ID]);
            if (dataDic.ContainsKey(name))
            {
                dataDic[name].LoadData(data);
            }
            else if(name != 0)
            {
                Debug.LogError($"datas에 없는 정보가 들어옴 이름 : {name}");
            }
        }
    }
}
