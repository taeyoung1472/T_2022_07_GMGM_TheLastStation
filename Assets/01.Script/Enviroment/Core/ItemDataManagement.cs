using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemDataManagement : MonoBehaviour
{
    public static Dictionary<ItemCategory, DT> Dict = new Dictionary<ItemCategory, DT>();

    private void Awake()
    {
        Init();
    }
    private static void Init()
    {
        Dict.Clear();

        ItemDataSO item;
        for (int i = 1; i <= Directory.GetFiles($"Assets/Resources/SO/Item/Item").Length / 2; i++)
        {
            item = Resources.Load($"SO/Item/Item/ID {i}") as ItemDataSO;
            Debug.Log($"item : {i}");
            if (!Dict.ContainsKey(item.category))
            {
                Debug.Log($"New Item Instantiate! {item.category}");
                Dict.Add(item.category, new DT());
            }
            else
            {
                Debug.Log($"Item Add! {item.category}");
                Dict[item.category].DTS.Add(item);
            }
        }
    }
    public class DT
    {
        public List<ItemDataSO> DTS = new List<ItemDataSO>();
    }
}
