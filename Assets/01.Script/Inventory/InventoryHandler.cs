using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler Instance;

    public Dictionary<ItemDataSO, VirtualItem> itemsDic = new Dictionary<ItemDataSO, VirtualItem>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public ItemController[] InventoryItems;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(ItemDataSO itemDataSO)
    {
        if (itemsDic.ContainsKey(itemDataSO))//이미 아이템이 있는경우
        {
            if (itemDataSO.maxStackAbleCount > itemsDic[itemDataSO].Amount)//만약 쌓일수 있는 여유공간이 있으면
            {
                itemsDic[itemDataSO].Amount++;
            }
            else
            {
                //추가해야지 마크에서 아이템 64게먹고 또먹을려고 하면 하나 더 늘잖아 근데 이건 나중에 생각해보고
            }
        }
        else//아닌경우
        {
            itemsDic.Add(itemDataSO, new VirtualItem(itemDataSO, Instantiate(InventoryItem, ItemContent)));
        }
        #region Legarcy
        /*if (itemDataSO.IsStackable())//필요 없을듯
{
    if (itemsDic.ContainsKey(itemDataSO))//이미 아이템이 있는경우
    {
        if(itemDataSO.maxStackAbleCount > itemsDic[itemDataSO].amount)//만약 쌓일수 있는 여유공간이 있으면
        {
            itemsDic[itemDataSO].amount++;
        }
        else
        {
            //추가해야지 마크에서 아이템 64게먹고 또먹을려고 하면 하나 더 늘잖아 근데 이건 나중에 생각해보고
        }
    }
    else//아닌경우
    {
        itemsDic.Add(itemDataSO, new VirtualItem(itemDataSO));
    }
    /*bool itemAlreadyInInventory = false;
    foreach (VirtualItem invenitem in Items.Values)
    {
        if (invenitem.itemType == itemDataSO.itemType)
        {
            invenitem.amout ++;
            itemAlreadyInInventory = true;
        }
    }
    if (!itemAlreadyInInventory)
    {
        Items.Add(itemDataSO);
    }
}
else
{
    itemsDic.Add(itemDataSO);
}*/
        #endregion
    }
    public void Remove(ItemDataSO itemDataSO)
    {
        Destroy(itemsDic[itemDataSO].uiContent);
        itemsDic.Remove(itemDataSO);//된거같음 
    }

    public void ListItems()//그니까 이게 껏다 키면은 다 삭제하고 생성하고 이러면은 메모리 손실이 많이나고 GC가 많이돌아 안좋은 코드임
    {
        /*foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(ItemDataSO item in itemsDic.Keys)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemSprite").GetComponent<Image>();
            var itemAmout = obj.transform.Find("AmountText").GetComponent<TextMeshProUGUI>();
            itemName.text = item.name;
            itemIcon.sprite = item.profileImage;
            if (item.amout > 1)
            {
                itemAmout.SetText(item.amout.ToString());
            }
            else
            {
                itemAmout.SetText("");
            }
        }*/
    }
}
public class VirtualItem
{
    //제작하고 음식 아마? 일다
    public VirtualItem(ItemDataSO _data, GameObject _uiContent)
    {
        data = _data;
        uiContent = _uiContent;
        var itemName = uiContent.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        var itemIcon = uiContent.transform.Find("ItemSprite").GetComponent<Image>();
        var itemAmout = uiContent.transform.Find("AmountText").GetComponent<TextMeshProUGUI>();
        itemName.text = data.name;
        itemIcon.sprite = data.profileImage;
        amountText = itemAmout;
    }//이게 만들때잖아 그러니까 Data 넣어주고 이게 생성자를 호출해야지 ㅎ
    public ItemDataSO data;
    private int amount = 1;//일단 내가볼땐 amount 초기가ㅄ이 0이
    public int Amount { get { return amount; } set
        {
            amountText.SetText($"{value}");
            amount = value;
        } 
    }
    public GameObject uiContent;
    TextMeshProUGUI amountText = null;//잘했어
}