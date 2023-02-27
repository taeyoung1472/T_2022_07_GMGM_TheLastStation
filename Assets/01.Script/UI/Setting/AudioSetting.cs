using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class AudioSetting : MonoBehaviour
{
    private float[] values = { -80, -27, -24, -21, -18, -15, -12, -9, -6, -3, 0 };
    private int curIndex;
    private int CurIndex { get { return curIndex; } set 
        {
            curIndex = Mathf.Clamp(value, 0, 10);
            controller.ChangeVolume(valueName, values[curIndex]);
            indexTmp.text = $"{curIndex}";
        } 
    }

    [Header("[참조]")]
    [SerializeField] private AudioController controller;
    [SerializeField] private TextMeshProUGUI indexTmp;
    [SerializeField] private Button audioUpBtn;
    [SerializeField] private Button audioDownBtn;

    [Header("[정보]")]
    [SerializeField] private string valueName;

    public void Start()
    {
        audioUpBtn.onClick.AddListener(() => CurIndex++);
        audioDownBtn.onClick.AddListener(() => CurIndex--);

        CurIndex = values.Length -1;
    }
}
