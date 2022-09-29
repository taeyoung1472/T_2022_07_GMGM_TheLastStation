using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    List<ItemDataSO> list = new List<ItemDataSO>();
    

    private void Start()
    {
        foreach (var dt in ItemDataManagement.Dict[ItemCategory.Medicine].DTS)
        {
            list.Add(dt);
        }
        for(int i = 0; i < Random.Range(2,6); i++)
        InventoryHandler.Instance.Add(list[Random.Range(0, list.Count)]);
    }
}
