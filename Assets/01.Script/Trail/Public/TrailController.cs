using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrailController : MonoBehaviour
{
    [SerializeField] private Text trailText;
    [SerializeField] private float textDelay;
    [SerializeField] TrailElement[] trailElement;
    [SerializeField] private AudioSource writeSource;
    private float writeSoundGoal;
    private int curTrailIndex;
    public void Start()
    {
        StartCoroutine(TrailSystem());
    }
    public void Update()
    {
        writeSource.volume = Mathf.Lerp(writeSource.volume, writeSoundGoal, Time.deltaTime * 10);
    }
    IEnumerator TrailSystem()
    {
        while(curTrailIndex < trailElement.Length)
        {
            trailText.text = "";
            string targetStr = trailElement[curTrailIndex].GetNextString(ref curTrailIndex);
            if (targetStr == "")
            {
                //Evnet 실행될때
            }
            else
            {
                writeSoundGoal = 0.5f;
                Sequence seq = DOTween.Sequence();
                trailText.DOText(targetStr, textDelay * ((float)targetStr.Length / 10f)).SetEase(Ease.Linear).OnComplete(() => writeSoundGoal = 0);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                if (trailText.text != targetStr)
                {
                    writeSoundGoal = 0;
                    trailText.DOKill();
                    trailText.text = targetStr;
                    yield return new WaitForSeconds(0.1f);
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}

[Serializable]
public class TrailElement
{
    int curIndex;
    public string[] textArr;
    public UnityEvent callbackEvent;
    public string GetNextString(ref int index)
    {
        string returnStr = "";
        try
        {
            returnStr = textArr[curIndex];
        }
        catch
        {
            //그냥 마지막
        }
        curIndex++;
        if(curIndex == textArr.Length + 1)
        {
            Debug.Log("한 싸이클 끝남");
            index++;
            callbackEvent?.Invoke();
            return "";
        }
        return returnStr;
    }
}