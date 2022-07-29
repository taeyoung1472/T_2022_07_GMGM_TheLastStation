using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private List<Background> backgrounds;
    [SerializeField] private List<BackgroundData> backgroundDatas;
    [SerializeField] private float speed;

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
            if (backgrounds[i].transform.position.z < -168)
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
    }

    private void LateUpdate()
    {
        for (int i = 0; i < 2; i++)
        {
            if (backgrounds[i].transform.position.z < -168)
            {
                backgrounds[i].transform.position = backgrounds[i == 0 ? 1 : 0].transform.position + new Vector3(0, 0, 168);
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