using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleTon<UIManager>
{
    #region 플레이어 카드 UI 관련
    [Header("플레이어 카드 UI 관련")]
    [SerializeField] private TextMeshProUGUI characterCardName;
    [SerializeField] private TextMeshProUGUI characterCardDesc;
    [SerializeField] private Image characterCardProfile;
    #endregion

    #region 제작 UI 관련
    [Header("더미 UI 관련")]
    [SerializeField] private GameObject dummyPanel;
    #endregion

    #region 지도 UI 관련
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private Image stationProfileTmp;
    [SerializeField] private TextMeshProUGUI stationNameTmp;
    [SerializeField] private TextMeshProUGUI stationDescTmp;
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

    public void Update()
    {
        DisplayVirtualTrain();
    }

    public void SetCharacterCardInfo(CharacterData data)
    {
        characterCardName.text = data.name;
        characterCardDesc.text = data.desc;
        characterCardProfile.sprite = data.profile;
    }

    public void DisplayWorkStation(bool isDisplay)
    {
        dummyPanel.SetActive(isDisplay);
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
        virtualTrainRect.anchoredPosition = new Vector2((curLength / (totalLength * 168)) * trainProgressBar.rectTransform.sizeDelta.x, 0);
    }
}
