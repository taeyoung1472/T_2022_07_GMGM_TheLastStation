using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SunBan : MonoBehaviour
{
   Dictionary<ItemCategory, DT> dict = new Dictionary<ItemCategory, DT>();

   ItemDataSO item;

    private void Awake()
    {
        for (int i = 1; i <= Directory.GetFiles($"Assets/Resources/SO/Item/Item").Length / 2; i++)
        {
            item = Resources.Load($"SO/Item/Item/ID {i}") as ItemDataSO;
            Debug.Log($"item : {i}");
            if (!dict.ContainsKey(item.category))
            {
                dict.Add(item.category, new DT());
            }
            else
            {
                dict[item.category].DTS.Add(item);
            }
        }
    }
    class DT
    {
        public List<ItemDataSO> DTS = new List<ItemDataSO>();
    }
}
