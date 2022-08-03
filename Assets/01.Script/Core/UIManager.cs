using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoSingleTon<UIManager>
{
    #region 플레이어 카드 UI 관련
    [Header("플레이어 카드 UI 관련")]
    [SerializeField] private RectTransform playerCard;
    [SerializeField] private TextMeshProUGUI characterCardName;
    [SerializeField] private TextMeshProUGUI characterCardDesc;
    [SerializeField] private Image characterCardProfile;
    private CharacterData prevData;
    #endregion

    #region 지도 UI 관련
    [Header("지도 UI 관련")]
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private Image stationProfileTmp;
    [SerializeField] private TextMeshProUGUI stationNameTmp;
    [SerializeField] private TextMeshProUGUI stationDescTmp;
    private bool isActiveMap = false;
    #endregion

    #region 인벤토리 UI 관련
    [Header("인벤토리 UI 관련")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryExitPanel;
    [SerializeField] private TextMeshProUGUI inventoryNameTMP;
    [SerializeField] private TextMeshProUGUI inventoryDescTMP;
    private bool isActiveInventory;
    #endregion

    #region 진행도 관련
    [Header("진행도 관련")]
    [SerializeField] private RectTransform virtualTrainRect;
    [SerializeField] private Image trainProgressBar;
    [SerializeField] private Image checkPointAnchor;
    private float totalLength;
    private float curLength;
    public float CurLength { get { return curLength; } set { curLength = value; } }
    #endregion

    #region 제작 UI 관련
    [Header("제작 UI 관련")]
    [SerializeField] private ItemCraft[] itemCraft;
    [SerializeField] private GameObject itemCraftPanel;
    [SerializeField] private TextMeshProUGUI craftTableNameTMP;
    [SerializeField] private TextMeshProUGUI craftItemNameTMP;
    [SerializeField] private TextMeshProUGUI craftItemDescTMP;
    [SerializeField] private TextMeshProUGUI craftItemResourceTMP;
    [SerializeField] private Image craftItemProfile;
    [SerializeField] private Color craftAbleColor;
    [SerializeField] private Color craftDisAbleColor;
    private bool isActiveCraftPanel;
    #endregion

    #region 조종 UI 관련
    [SerializeField] private GameObject controllPanel;
    [SerializeField] private bool isActiveControllPanel;
    #endregion

    #region 사운드 관련
    [Header("사운드 관련")]
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;
    #endregion

    public void Update()
    {
        DisplayVirtualTrain();
    }

    public void SetCharacterCardInfo(CharacterData data)
    {
        if (prevData == data) return;
        Sequence seq = DOTween.Sequence();
        OnOffSound(false);
        seq.Append(playerCard.DOAnchorPosY(-300, 0.5f));
        seq.AppendCallback(() =>
        {
            characterCardName.text = data.name;
            characterCardDesc.text = data.desc;
            characterCardProfile.sprite = data.profile;
            OnOffSound(true);
        });
        seq.Append(playerCard.DOAnchorPosY(0, 0.5f));
        prevData = data;
    }

    public void ProductProgressBar(BackgroundData[] datas)
    {
        totalLength = 0;
        for (int i = 0; i < datas.Length; i++)
        {
            totalLength += datas[i].length;
        }
        float gridLength = trainProgressBar.rectTransform.sizeDelta.x / totalLength;

        int curLength = 0;
        for (int i = 0; i < datas.Length; i++)
        {
            curLength += datas[i].length;
            RectTransform rect = Instantiate(checkPointAnchor, trainProgressBar.transform).GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(gridLength * curLength, 0);
            rect.gameObject.SetActive(true);
        }
    }

    public void DisplayVirtualTrain()
    {
        if (virtualTrainRect == null) return;
        virtualTrainRect.anchoredPosition = new Vector2(Mathf.Clamp(curLength / (totalLength * 384 + 155) * trainProgressBar.rectTransform.sizeDelta.x, 0, trainProgressBar.rectTransform.sizeDelta.x), 0);
    }

    public void ActiveMap()
    {
        isActiveMap = !isActiveMap;
        mapPanel.SetActive(isActiveMap);
        ActiveTime(!isActiveMap);
        OnOffSound(isActiveMap);
    }

    public void ActiveInventory(bool isExit = false)
    {
        isActiveInventory = !isActiveInventory;
        inventoryPanel.SetActive(isActiveInventory);
        ActiveTime(!isActiveInventory);
        OnOffSound(isActiveInventory);
        if(inventoryExitPanel != null)
        {
            inventoryExitPanel.SetActive(isExit);
        }
    }

    public void ActiveCraftTable()
    {
        isActiveCraftPanel = !isActiveCraftPanel;
        itemCraftPanel.SetActive(isActiveCraftPanel);
        ActiveTime(!isActiveCraftPanel);
        OnOffSound(isActiveCraftPanel);
    }

    public void ActiveControllPanel()
    {
        isActiveControllPanel = !isActiveControllPanel;
        controllPanel.SetActive(isActiveControllPanel);
    }

    public void SetInventoryUI(ItemDataSO data)
    {
        inventoryNameTMP.text = data.name;
        inventoryDescTMP.text = data.desc;
    }

    public void SetCraftTable(string name, CraftDataSO[] craftDatas)
    {
        craftTableNameTMP.text = name;
        int i = 0;
        SetCraftTableUI(craftDatas[0]);
        for (i = 0; i < craftDatas.Length; i++)
        {
            itemCraft[i].Set(craftDatas[i]);
        }
        for (int j = i; j < 12; j++)
        {
            itemCraft[j].Set(null);
        }
    }
    
    public void SetCraftTableUI(CraftDataSO data)
    {
        InventoryHandler.Instance.CraftData = data;
        craftItemNameTMP.text = data.targetItem.name;
        craftItemDescTMP.text = data.targetItem.desc;
        craftItemProfile.sprite = data.targetItem.profileImage;

        string resourceStr = "";

        for (int i = 0; i < data.craftElements.Length; i++)
        {
            CraftElement element = data.craftElements[i];

            //InventoryHandler.Instance.ReturnAmout(element.data)
            //{InventoryHandler.Instance.ReturnAmout(element.data)}

            if (InventoryHandler.Instance.ReturnAmout(element.data) < element.amount)//만약에 가진게 없으면 
            {
                resourceStr += $"<#{ColorUtility.ToHtmlStringRGB(craftDisAbleColor)}>";
            }
            else
            {
                resourceStr += $"<#{ColorUtility.ToHtmlStringRGB(craftAbleColor)}>";
            }

            resourceStr += $"{element.data.name} {InventoryHandler.Instance.ReturnAmout(element.data)} / {element.amount}";

            resourceStr += "</color>";
            resourceStr += "\n";
        }

        craftItemResourceTMP.text = resourceStr;
    }

    public void ActiveTime(bool value)
    {
        Time.timeScale = value ? 1 : 0;
    }

    private void OnOffSound(bool value)
    {
        if (value)
        {
            PlayAudio(openClip, 0.1f);
        }
        else
        {
            PlayAudio(closeClip, 0.1f);
        }
    }

    private void PlayAudio(AudioClip clip, float randPitch)
    {
        float tgtPitch = 1 + Random.Range(-randPitch, randPitch);
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(clip, tgtPitch);
    }
}
