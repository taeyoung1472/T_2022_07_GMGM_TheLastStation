using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryHandler : MonoSingleTon<InventoryHandler>
{
    private Dictionary<ItemDataSO, VirtualItem> itemsDic = new Dictionary<ItemDataSO, VirtualItem>();

    [SerializeField] private Transform ItemContent;
    [SerializeField] private GameObject InventoryItem;
    [SerializeField] private ItemDataSO testSO;
    [SerializeField] private List<Transform> buttonList = new List<Transform>();
    Dictionary<string, GameObject> buttonDic = new Dictionary<string, GameObject>();

    [SerializeField] private bool isInit = false;

    private CraftDataSO craftData;
    public CraftDataSO CraftData { get { return craftData; } set { craftData = value; } }

    public void Start()
    {
        if (!isInit)
        {
            foreach (var data in JsonManager.Instance.Data.inventory)
            {
                for (int i = 0; i < data.count; i++)
                {
                    Add(data.itemData);
                }
            }
        }

        foreach (var btn in buttonList)
        {
            buttonDic.Add(btn.gameObject.name, btn.gameObject);
        }
        if(buttonList.Count == 0) { return; }
        foreach (var str in JsonManager.Instance.Data.openBox)
        {
            buttonDic[str].transform.Find("ButtonItem").gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        if (!isInit)
        {
            JsonManager.Instance.Data.inventory = new List<InventoryItemData>();
            foreach (var data in itemsDic.Keys)
            {
                InventoryItemData itemData = new InventoryItemData();

                int cnt = ReturnAmout(data);

                itemData.itemData = data;
                itemData.count = cnt;

                JsonManager.Instance.Data.inventory.Add(itemData);
            }
        }
        else
        {
            foreach (var data in itemsDic.Keys)
            {
                bool hasKey = false;
                InventoryItemData hasDt = null;
                foreach (var dt in JsonManager.Instance.Data.inventory)
                {
                    if(dt.itemData == data)
                    {
                        hasDt = dt;
                        hasKey = true;
                    }
                }
                if (hasKey)
                {
                    hasDt.count += itemsDic[data].ReturnAmout();
                }
                else
                {
                    InventoryItemData itemData = new InventoryItemData();

                    int cnt = ReturnAmout(data);

                    itemData.itemData = data;
                    itemData.count = cnt;

                    JsonManager.Instance.Data.inventory.Add(itemData);
                }
            }
        }
        JsonManager.Instance.Save();
    }

    public void Add(ItemDataSO itemDataSO)
    {
        if (itemsDic.ContainsKey(itemDataSO))//�̹� �������� �ִ°��
        {
            if (itemDataSO.maxStackAbleCount > itemsDic[itemDataSO].items[itemsDic[itemDataSO].items.Count - 1].Amount)//���� ���ϼ� �ִ� ���������� ������
            {
                itemsDic[itemDataSO].items[itemsDic[itemDataSO].items.Count - 1].Amount++;
            }
            else
            {
                itemsDic[itemDataSO].items.Add(new LocalItem(itemDataSO, Instantiate(InventoryItem, ItemContent)));
                //�̰Ŵ� List���ٰ� Add�ϸ� �ɵ�
                //�߰��ؾ��� ��ũ���� ������ 64�Ը԰� �Ǹ������� �ϸ� �ϳ� �� ���ݾ� �ٵ� �̰� ���߿� �����غ���
            }
        }
        else//�ƴѰ��
        {
            itemsDic.Add(itemDataSO, new VirtualItem(itemDataSO, Instantiate(InventoryItem, ItemContent)));
        }
        #region Legarcy
        /*if (itemDataSO.IsStackable())//�ʿ� ������
{
    if (itemsDic.ContainsKey(itemDataSO))//�̹� �������� �ִ°��
    {
        if(itemDataSO.maxStackAbleCount > itemsDic[itemDataSO].amount)//���� ���ϼ� �ִ� ���������� ������
        {
            itemsDic[itemDataSO].amount++;
        }
        else
        {
            //�߰��ؾ��� ��ũ���� ������ 64�Ը԰� �Ǹ������� �ϸ� �ϳ� �� ���ݾ� �ٵ� �̰� ���߿� �����غ���
        }
    }
    else//�ƴѰ��
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
        foreach (LocalItem item in itemsDic[itemDataSO].items)
        {
            Destroy(item.uiContent);
        }
        itemsDic.Remove(itemDataSO);//�ȰŰ��� 
    }

    public int ReturnAmout(ItemDataSO itemDataSO)
    {
        if (!itemsDic.ContainsKey(itemDataSO))
        {
            return 0;
        }
        return itemsDic[itemDataSO].ReturnAmout();
    }

    public void Use(ItemDataSO itemDataSO, int useAmount)
    {
        //������so ī����
        /*int cnt = ReturnAmout(itemDataSO);
        cnt -= upCnt;
        itemsDic[itemDataSO].items[0].Amount = cnt; 
        itemsDic[itemDataSO].items.Remove(new LocalItem(itemDataSO, Instantiate(InventoryItem, ItemContent)));
        print(itemsDic[itemDataSO].items.Count);*/
        int cnt = ReturnAmout(itemDataSO);//���� ���׷��̵� ��=�µ� 3�԰� �ʿ��ѵ� ������ 3�Ժ��� ������
        if(cnt < useAmount)//������ ����
        {
            Debug.LogError("���� : �Ѱ�ġ �ʰ�!");
            return;
        }
        itemsDic[itemDataSO].Use(useAmount);//�ƴϸ� ���
    }

    public void ListItems()//�״ϱ� �̰� ���� Ű���� �� �����ϰ� �����ϰ� �̷����� �޸� �ս��� ���̳��� GC�� ���̵��� ������ �ڵ���
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

    public void DestroyHelper(GameObject obj)
    {
        Destroy(obj);
    }

    public void UpgradeItem()
    {
        foreach (CraftElement data in craftData.craftElements)
        {
            ItemDataSO itemData = data.data;
            if(ReturnAmout(itemData) < data.amount)
            {
                return;
            }
        }
        foreach (CraftElement data in craftData.craftElements)
        {
            Use(data.data, data.amount);
        }
        UIManager.Instance.SetCraftTableUI(craftData);
        for (int i = 0; i < craftData.amount; i++)
        {
            Add(craftData.targetItem);
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
           print(ReturnAmout(testSO));
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Use(testSO, 2);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Add(testSO);
        }
    }
    
}


public class VirtualItem
{
    public VirtualItem(ItemDataSO _data, GameObject _uiContent)
    {
        items.Add(new LocalItem(_data, _uiContent));
    }
    public int ReturnAmout()
    {
        int count = 0;
        foreach (LocalItem item in items)
        {
            count += item.Amount; 
        }
        return count;
    }
    public void Use(int useAmount)//�̰Ŵ� �����Լ�
    {//���࿡ ��ũ�� ���õ�� ����
        int value = items[items.Count - 1].Amount;
        int garbageValue = value - useAmount;//����ϰ� ���������� �̷���
        if(garbageValue <= 0)
        {//���⼭ �ϳ��� ������ �� ���� �ִ°� ��ųʸ����� ���ִ°Ű� Destroy�� Mono��ӹ޾� �ɵ� ����
            InventoryHandler.Instance.DestroyHelper(items[items.Count - 1].uiContent);
            items.RemoveAt(items.Count - 1);//������� ��ü�� ã�Ƽ� ����°Ű� RemoveAt�� Index������� ����°�
            if (garbageValue != 0)
            {
                Use(Mathf.Abs(garbageValue));
            }
        }
        else
        {
            items[items.Count - 1].Amount = garbageValue;
        }//�׽�Ʈ �غ��� �̷��� �ؾ��� InventroyHandler�� ª���� �׷��°� �ڵ� �������� ���� ���� �̰� ��ũ��Ʈ�� �پ��־ �׷���
        //������ �̰� �� ���� ����
        //�ڵ� �������� ���� �����׽�Ʈ
    }
    public List<LocalItem> items = new List<LocalItem>();//���� �̰������� �տ������� �������� �� �׷��� �ִµ� �ϴ� �̷��� �صΰ� ���� ����
    //�̷��� 2�� Ŭ������ �Ǵ� ������  Dictionary�ϱ� Key�� �ߺ��� �Ұ����� �ٵ� �κ��丮�� �ߺ��ɼ� ���ݾ� ��ũó��
    //�׷��ϱ� �̷������� Key���� �����ϴ� VirtualItem�� �װ��� �����ϴ� LocalItem�� �ִ°����̰� ���䷱�� ������
}

public class LocalItem
{
    //�����ϰ� ���� �Ƹ�? �ϴ�
    public LocalItem(ItemDataSO _data, GameObject _uiContent)
    {
        data = _data;
        uiContent = _uiContent;
        var itemIcon = uiContent.transform.Find("ItemSprite").GetComponent<Image>();
        var itemAmout = uiContent.transform.Find("AmountText").GetComponent<TextMeshProUGUI>();
        var button = uiContent.GetComponent<Button>();
        button.onClick.AddListener(() => UIManager.Instance.SetInventoryUI(data));
        button.onClick.AddListener(() => UISoundManager.Instance.LightClick());
        UIManager.Instance.SetInventoryUI(data);
        itemIcon.sprite = data.profileImage;
        amountText = itemAmout;
    }//�̰� ���鶧�ݾ� �׷��ϱ� Data �־��ְ� �̰� �����ڸ� ȣ���ؾ��� ��
    public ItemDataSO data;
    private int amount = 1;//�ϴ� �������� amount �ʱⰡ���� 0��
    public int Amount
    {
        get { return amount; }
        set
        {
            amount = value;
            amountText.SetText($"{value}");
        }
    }
    public GameObject uiContent;
    TextMeshProUGUI amountText = null;//���߾�
}