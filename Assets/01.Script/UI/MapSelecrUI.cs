using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class MapSelecrUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stationMapNameTmp;
    [SerializeField] private Transform content = null;
    [SerializeField] private GameObject gridPrefab;

    #region Test
    [SerializeField] private StationDataSO data;
    public void Start()
    {
        Init();
    }
    #endregion

    public void Init()
    {
        stationMapNameTmp.text = data.stationName;
        for (int i = 0; i < data.pharmingDatas.Count; i++)
        {
            MapGrid grid = Instantiate(gridPrefab, content).AddComponent<MapGrid>();
            grid.gameObject.SetActive(true);
            grid.Init(data.pharmingDatas[i]);
        }
    }
}

[HideInInspector]
public class MapGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private TextMeshProUGUI mapGridName;
    private Image image; 
    private List<Image> warringGrids = new List<Image>();
    private int warringValue = 0;
    private float doColorDelay = 0.25f;
    private PharmingDataSO data = null;

    private float colorMultiflyValue;
    private float ColorMultiflyValue
    {
        set
        {
            colorMultiflyValue = value;

            Func<Color, Color> generateColor = (Color input) => { input.a = 1; return input; };

            for (int i = 0; i < warringValue; i++)
            {
                warringGrids[i].DOColor(generateColor(new Color(0.75f, 0, 0, 1) * colorMultiflyValue), doColorDelay);
            }
            for (int i = warringValue; i < warringGrids.Count; i++)
            {
                warringGrids[i].DOColor(generateColor(Color.gray * colorMultiflyValue), doColorDelay);
            }
            mapGridName.DOColor(generateColor(Color.white * 0.75f * colorMultiflyValue), doColorDelay);
            image.color = generateColor(Color.gray * 0.5f * colorMultiflyValue);
        }
    }

    public void Init(PharmingDataSO data)
    {
        mapGridName = transform.Find("GridName").GetComponent<TextMeshProUGUI>();
        warringGrids.AddRange(transform.Find("Warring").GetComponentsInChildren<Image>());
        image = GetComponent<Image>();

        mapGridName.text = data.pharmingName;
        warringValue = data.pharmingDangerLevel;
        ColorMultiflyValue = 0.5f;
        this.data = data;
    }

    public void Active()
    {
        ColorMultiflyValue = 1f;
    }

    public void DeActive()
    {
        ColorMultiflyValue = 0.5f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Active();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DeActive();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StationGenerator.Instance.GenerateStation(data.mapPattern);
    }
}