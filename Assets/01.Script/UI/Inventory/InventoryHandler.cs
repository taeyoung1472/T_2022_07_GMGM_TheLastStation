using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryHandler : MonoSingleTon<InventoryHandler>
{
    private Dictionary<ItemDataSO, VirtualItem> itemsDic = new Dictionary<ItemDataSO, VirtualItem>();
    private Dictionary<ItemCategory, CategoryUI> categoryDic = new Dictionary<ItemCategory, CategoryUI>();

    [SerializeField] private Transform ItemContent;
    [SerializeField] private GameObject InventoryItem;
    [SerializeField] private ItemDataSO testSO;

    [Header("Prefab")]
    [SerializeField] private ItemGrid gridPrefab;
    [SerializeField] private CategoryUI categoryPrefab;

    [SerializeField] private List<Transform> buttonList = new List<Transform>();
    private Dictionary<string, GameObject> buttonDic = new Dictionary<string, GameObject>();

    [SerializeField] private bool isInit = false;

    public void Start()
    {
        if (!isInit)
        {
            foreach (var data in JsonManager.Data.inventory)
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
        if (buttonList.Count == 0) { return; }
        foreach (var str in JsonManager.Data.openBox)
        {
            buttonDic[str].transform.GetComponentInChildren<SpriteButton>().gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        if (!isInit)
        {
            JsonManager.Data.inventory = new List<InventoryItemData>();
            foreach (var data in itemsDic.Keys)
            {
                InventoryItemData itemData = new InventoryItemData();

                int cnt = ReturnAmout(data);

                itemData.itemData = data;
                itemData.count = cnt;

                JsonManager.Data.inventory.Add(itemData);
            }
        }
        else
        {
            foreach (var data in itemsDic.Keys)
            {
                bool hasKey = false;
                InventoryItemData hasDt = null;
                foreach (var dt in JsonManager.Data.inventory)
                {
                    if (dt.itemData == data)
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

                    JsonManager.Data.inventory.Add(itemData);
                }
            }
        }
        JsonManager.Save();
    }

    public void Add(ItemDataSO data)
    {
        if (!categoryDic.ContainsKey(data.category))
        {
            categoryDic.Add(data.category, Instantiate(categoryPrefab, ItemContent));
        }

        if (itemsDic.ContainsKey(data))                                                                 // 이미 아이템이 있는경우
        {
            if (data.maxStackAbleCount > itemsDic[data].items[itemsDic[data].items.Count - 1].Amount)   // 만약 쌓일수 있는 여유공간이 있으면
            {
                itemsDic[data].items[itemsDic[data].items.Count - 1].Amount++;
            }
            else
            {
                itemsDic[data].items.Add(new LocalItem(data, Instantiate(gridPrefab, categoryDic[data.category].Content)));
            }
        }
        else                                                                                            // 아닌경우
        {
            itemsDic.Add(data, new VirtualItem(data, Instantiate(gridPrefab, categoryDic[data.category].Content)));
        }
    }

    public void Remove(ItemDataSO itemDataSO)
    {
        foreach (LocalItem item in itemsDic[itemDataSO].items)
        {
            Destroy(item.itemGrid);
        }
        itemsDic.Remove(itemDataSO); // 된거같음 
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
        int cnt = ReturnAmout(itemDataSO);          // 수량 체크
        if (cnt < useAmount)                        // 만약에 수요량이 수용량보다 많으면
        {
            Debug.LogError("오류 : 한계치 초과!");   // 오류
            return;
        }
        itemsDic[itemDataSO].Use(useAmount);        // 수용량에서 수요량만큼 사용하기
    }

    public void DestroyHelper(GameObject obj)
    {
        Destroy(obj);
    }

    #region Debug Code
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
    #endregion
}


public class VirtualItem
{
    public List<LocalItem> items = new List<LocalItem>();
    public VirtualItem(ItemDataSO _data, ItemGrid grid)
    {
        items.Add(new LocalItem(_data, grid));
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
    public void Use(int useAmount)
    {
        int value = items[items.Count - 1].Amount;
        int garbageValue = value - useAmount;
        if (garbageValue <= 0)
        {
            InventoryHandler.Instance.DestroyHelper(items[items.Count - 1].itemGrid.gameObject);    // 그리드 지우기
            items.RemoveAt(items.Count - 1);                                                        // 리스트에서도 지우기
            if (garbageValue != 0)
            {
                Use(Mathf.Abs(garbageValue));
            }
        }
        else
        {
            items[items.Count - 1].Amount = garbageValue;
        }
    }
}

public class LocalItem
{
    public ItemGrid itemGrid;
    private ItemDataSO data;

    public int Amount
    {
        get { return itemGrid.Count; }
        set
        {
            itemGrid.Count = value;
        }
    }

    public LocalItem(ItemDataSO data, ItemGrid grid)
    {
        this.data = data;
        grid.Init(data, 1);
        grid.RegistAction(() => {
            UIManager.Instance.SetInventoryUI(data);
            UISoundManager.Instance.LightClick();
        });
        itemGrid = grid;
    }
}