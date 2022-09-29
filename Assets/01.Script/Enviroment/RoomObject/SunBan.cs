using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SunBan : MonoBehaviour
{
   Dictionary<int, ItemDataSO> dict = new Dictionary<int, ItemDataSO>();

   ItemDataSO item;

    private void Awake()
    {
        for (int i = 0; i < Directory.GetFiles($"06.SO/Item/Item").Length; i++)
        {
            item = Directory.GetFiles($"06.SO/Item/Item/ID {i}") as ItemDataSO;
            Debug.Log(item);
            dict.Add((int)item.category, item);
        }
    }
}
