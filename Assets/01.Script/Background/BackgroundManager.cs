using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BackgroundManager : MonoSingleTon<BackgroundManager>
{
    [Header("Main")]
    [SerializeField] private List<Background> backgrounds;
    [SerializeField] private float speed;
    private List<BackgroundData> backgroundDatas = new List<BackgroundData>();
    public float Speed { get { return speed; } set { if (isCanControllSpeed) { speed = value; } } }

    [Header("Serve")]
    [SerializeField] private List<Transform> backgroundsMiddle;
    [SerializeField] private float middleSpeedValue;
    [SerializeField] private List<Transform> backgroundsFar;
    [SerializeField] private float farSpeedValue;

    [Header("정보")]
    [SerializeField] private StationDataSO[] stationDataSO;

    bool isCanControllSpeed = true;
    bool isEnd = false;
    bool isEndLate = false;
    bool isEndPlace = false;
    bool isLoadScene = false;
    int curIndex;
    int curBackgroundIdx;
    private void Start()
    {
        foreach (var data in stationDataSO[JsonManager.Data.curStationIndex].backgroundDatas)
        {
            backgroundDatas.Add(data);
        }
        UIManager.Instance.SetMapUI(stationDataSO[JsonManager.Data.curStationIndex]);
        UIManager.Instance.ActiveLatterPanel(JsonManager.Data.curStationIndex);

        backgrounds[0].Active(BackgroundType.Start);
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
        if (!isCanControllSpeed)
        {
            speed = Mathf.Lerp(speed, 15, Time.deltaTime * 2);
        }
        for (int i = 0; i < 2; i++)
        {
            backgrounds[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (!isEndPlace)
            {
                UIManager.Instance.CurLength += speed * Time.deltaTime;
            }
            if (backgrounds[i].transform.position.z < -192)
            {
                if (isEnd)
                {
                    if (isEndPlace)
                    {
                        if (JsonManager.Data.curStationIndex == 1)
                        {
                            if (!isLoadScene)
                            {
                                isLoadScene = true;
                                GameManager.Instance.LoadDemoEnding();
                            }
                        }
                        else
                        {
                            if (!isLoadScene)
                            {
                                GameManager.Instance.LoadStation();
                                isLoadScene = true;
                            }
                        }
                        return;
                    }
                    isCanControllSpeed = false;
                    backgrounds[i].Active(BackgroundType.End);
                    continue;
                }
                backgrounds[i].Active(backgroundDatas[curBackgroundIdx].backgroundType);
                curIndex++;
                if (curIndex >= backgroundDatas[curBackgroundIdx].length)
                {
                    curIndex = 0;
                    curBackgroundIdx++;
                    if (curBackgroundIdx > backgroundDatas.Count - 1)
                    {
                        isEnd = true;
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
            if (backgrounds[i].transform.position.z < -192 && !isEndPlace)
            {
                if (isEndLate)
                {
                    if (backgrounds[i].transform.position.z < -192 && !isEndPlace)
                        isEndPlace = true;
                }
                backgrounds[i].transform.position = backgrounds[i == 0 ? 1 : 0].transform.position + new Vector3(0, 0, 192);
            }
        }
        isEndLate = isEnd;
        #region 중, 원경
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
        #endregion
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
    Start,
    End
}