using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BackgroundManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private List<Background> backgrounds;
    [SerializeField] private List<BackgroundData> backgroundDatas;
    [SerializeField] private float speed; 

    [Header("Serve")]
    [SerializeField] private List<Transform> backgroundsMiddle;
    [SerializeField] private float middleSpeedValue;
    [SerializeField] private List<Transform> backgroundsFar;
    [SerializeField] private float farSpeedValue;

    bool isEnd = false;
    int curIndex;
    int curBackgroundIdx;
    private void Start()
    {
        backgrounds[0].Active(backgroundDatas[curBackgroundIdx].backgroundType);
        curIndex++;
        if (curIndex >= backgroundDatas[curBackgroundIdx].length)
        {
            curIndex = 0;
            curBackgroundIdx++;
            if (curBackgroundIdx > backgroundDatas.Count - 1)
            {
                isEnd = true;
                speed = 0;
            }
        }
        backgrounds[1].Active(backgroundDatas[curBackgroundIdx].backgroundType);
        curIndex++;
        if (curIndex >= backgroundDatas[curBackgroundIdx].length)
        {
            curIndex = 0;
            curBackgroundIdx++;
            if (curBackgroundIdx > backgroundDatas.Count - 1)
            {
                isEnd = true;
                speed = 0;
            }
        }
        UIManager.Instance.ProductProgressBar(backgroundDatas.ToArray());
    }
    private void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            backgrounds[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
            UIManager.Instance.CurLength += speed * Time.deltaTime;
            if (backgrounds[i].transform.position.z < -192)
            {
                backgrounds[i].Active(backgroundDatas[curBackgroundIdx].backgroundType);
                curIndex++;
                if (curIndex >= backgroundDatas[curBackgroundIdx].length)
                {
                    curIndex = 0;
                    curBackgroundIdx++;
                    if (curBackgroundIdx > backgroundDatas.Count - 1)
                    {
                        isEnd = true;
                        speed = 0;
                    }
                }
            }
        }
        for (int i = 0; i < 2; i++)
        {
            backgroundsMiddle[i].transform.Translate(Vector3.back * speed * Time.deltaTime * middleSpeedValue);
        }
        for (int i = 0; i < 2; i++)
        {
            backgroundsFar[i].transform.Translate(Vector3.back * speed * Time.deltaTime * farSpeedValue);
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < 2; i++)
        {
            if (backgrounds[i].transform.position.z < -192)
            {
                backgrounds[i].transform.position = backgrounds[i == 0 ? 1 : 0].transform.position + new Vector3(0, 0, 192);
            }
        }
        for (int i = 0; i < 2; i++)
        {
            if (backgroundsMiddle[i].transform.position.z < -300)
            {
                backgroundsMiddle[i].transform.position = backgroundsMiddle[i == 0 ? 1 : 0].transform.position + new Vector3(0, 0, 300);
            }
        }
        for (int i = 0; i < 2; i++)
        {
            if (backgroundsFar[i].transform.position.z < -300)
            {
                backgroundsFar[i].transform.position = backgroundsFar[i == 0 ? 1 : 0].transform.position + new Vector3(0, 0, 300);
            }
        }
    }
}
[Serializable]
public class BackgroundData
{
    public BackgroundType backgroundType;
    public int length;
}
public enum BackgroundType
{
    City,
    Wood,
    Tunnel,
    Country,
}