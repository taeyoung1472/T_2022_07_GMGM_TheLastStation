using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler Instance;

    public List<ItemDataSO> Items = new List<ItemDataSO>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public ItemController[] InventoryItems;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(ItemDataSO itemDataSO)
    {
        Items.Add(itemDataSO);
    }
    public void Remove(ItemDataSO itemDataSO)
    {
        Items.Remove(itemDataSO);
    }
    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemSprite").GetComponent<Image>();

            itemName.text = item.name;
            itemIcon.sprite = item.profileImage;
        
        }
    }

}
