using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothShelf : Shelf
{
    List<ItemDataSO> list = new List<ItemDataSO>();

    public override void Effect()
    {
        foreach (var dt in ItemDataManagement.Dict[ItemCategory.Armor].DTS)
        {
            list.Add(dt);
        }
        for (int i = 0; i < Random.Range(2, 6); i++)
            InventoryHandler.Instance.Add(list[Random.Range(0, list.Count)]);
    }

    private void Start()
    {
        Effect();
    }
}
