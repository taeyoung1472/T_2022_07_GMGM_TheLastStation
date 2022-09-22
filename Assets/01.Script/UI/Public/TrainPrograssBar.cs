using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class TrainPrograssBar : MonoBehaviour
{
    [SerializeField] private GameObject pinPointPrefab;
    [SerializeField] private RectTransform sliderRectTransform;
    [SerializeField] private Transform pinPointParent;
    private Slider prograssSlider;
    private float totalDistance;
    private float curPosition;
    public float CurPosition { get { return curPosition; } 
        set 
        { 
            curPosition = value;
            prograssSlider.value = curPosition;
        } 
    }

    public void Awake()
    {
        prograssSlider = GetComponent<Slider>();
    }

    public void Init(BackgroundData[] datas)
    {
        totalDistance += 155;
        foreach (var data in datas)
        {
            totalDistance += data.length * 384;
        }

        prograssSlider.maxValue = totalDistance;
    }
}
