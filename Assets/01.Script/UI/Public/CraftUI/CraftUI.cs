using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    [Header("Craft")]
    [SerializeField] private TextMeshProUGUI craftTableNameTmp;
    [SerializeField] private Transform categoryContent;

    [Header("Desc")]
    [SerializeField] private TextMeshProUGUI itemNameTmp;
    [SerializeField] private TextMeshProUGUI itemDescTmp;
    [SerializeField] private Image itemImage;

    [Header("Prefab")]
    [SerializeField] private CategoryUI categoryUI;

    private Dictionary<ItemCategory, CategoryUI> categoryDic = new Dictionary<ItemCategory, CategoryUI>();

    public void Active(CraftDataSO[] datas, string tableName)
    {
        gameObject.SetActive(true);

        craftTableNameTmp.text = tableName;

        foreach (CraftDataSO data in datas)
        {
            if (!categoryDic.ContainsKey(data.targetItem.category))
            {
                categoryDic.Add(data.targetItem.category, Instantiate(categoryUI, categoryContent));
            }

            categoryDic[data.targetItem.category].Add(data.targetItem, () => DisplayDescPanel(data.targetItem));
        }
    }

    public void OnDisable()
    {
        foreach (CategoryUI ui in categoryDic.Values)
        {
            Destroy(ui.gameObject);
        }
        categoryDic.Clear();
    }

    public void DisplayDescPanel(ItemDataSO data)
    {
        itemNameTmp.text = data.itemName;
        itemDescTmp.text = data.itemDesc;
        itemImage.sprite = data.itemSprite;
    }
}