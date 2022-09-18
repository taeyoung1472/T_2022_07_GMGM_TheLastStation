using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleTon<UIManager>
{
    #region �÷��̾� ī�� UI ����
    [Header("�÷��̾� ī�� UI ����")]
    [SerializeField] private CharacterCardUI cardUI;
    #endregion

    #region ���� UI ����
    [Header("���� UI ����")]
    [SerializeField] private MapUI mapUI;
    #endregion

    #region �κ��丮 UI ����
    [Header("�κ��丮 UI ����")]
    [SerializeField] private InventoryUI inventoryUI;
    #endregion

    #region ���൵ ����
    [Header("���൵ ����")]
    [SerializeField] private TrainPrograssBar prograssBar;
    public float CurLength { get { return prograssBar.CurPosition; } set { prograssBar.CurPosition = value; } }
    #endregion

    #region ���� UI ����
    [Header("���� UI ����")]
    [SerializeField] private CraftUI craftUI;
    private bool isActiveCraftPanel;
    #endregion

    #region ���� UI ����
    [Header("���� UI ����")]
    [SerializeField] private GameObject controllPanel;
    [SerializeField] private bool isActiveControllPanel;
    #endregion

    #region ���� ����
    [Header("���� ����")]
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;
    #endregion

    #region ���� UI ����
    [Header("���� UI ����")]
    [SerializeField] private GameObject latterPanel_Busan;
    [SerializeField] private GameObject latterPanel_Sejong;
    #endregion

    public void ProductProgressBar(BackgroundData[] datas)
    {
        prograssBar.Init(datas);
    }

    #region Map
    public void ActiveMap()
    {
        mapUI.Active();
    }

    public void SetMapUI(StationDataSO data)
    {
        mapUI.SetData(data);
    }
    #endregion

    #region PlayerCard
    public void SetCharacterCardInfo(CharacterData data)
    {
        cardUI.ChangeCardUI(data);
    }
    #endregion

    #region Inventory
    public void SetInventoryUI(ItemDataSO data)
    {
        inventoryUI.SetUI(data);
    }
    public void ActiveInventory(bool isExit = false)
    {
        inventoryUI.Active();
    }
    #endregion

    public void ActiveCraftTable()
    {
        isActiveCraftPanel = !isActiveCraftPanel;
        craftUI.gameObject.SetActive(isActiveCraftPanel);
        ActiveTime(!isActiveCraftPanel);
        OnOffSound(isActiveCraftPanel);
    }

    public void ActiveControllPanel()
    {
        isActiveControllPanel = !isActiveControllPanel;
        controllPanel.SetActive(isActiveControllPanel);
    }

    public void ActiveLatterPanel(int idx)
    {
        switch (idx)
        {
            case 0:
                latterPanel_Busan.gameObject.SetActive(true);
                break;
            case 1:
                latterPanel_Sejong.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }



    public void SetCraftTable(string name, CraftDataSO[] craftDatas)
    {
        craftUI.Active(craftDatas, name);
    }

    public void ActiveTime(bool value)
    {
        Time.timeScale = value ? 1 : 0;
    }

    public void OnOffSound(bool value)
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
        AudioManager.Play(clip, tgtPitch);
    }
}
