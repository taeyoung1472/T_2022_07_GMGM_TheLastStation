using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrig : Shelf
{
    List<ItemDataSO> list = new List<ItemDataSO>();
    public override void Effect()
    {
        foreach (var dt in ItemDataManagement.Dict[ItemCategory.Food].DTS)
        {
            list.Add(dt);
        }
        for (int i = 0; i < Random.Range(2, 6); i++)
            InventoryHandler.Instance.Add(list[Random.Range(0, list.Count)]);
    }
}
