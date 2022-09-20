using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruin : MonoBehaviour,IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //건물 잔해: 20% 확률로 등장, '삽' 도구로 상호작용해서 제거
        //철골 잔해: 10% 확률로 등장, '줄톱' 도구로 상호작용해서 제거
        int building = 20;
        int iron = 10;
        int wholePercent = Random.Range(0, 100);
        RuinState ruinState = wholePercent < iron ? RuinState.IRON : wholePercent < iron + building ? RuinState.BUILDING : RuinState.NONE; 

        switch(ruinState)
        {
            case RuinState.NONE:
                Debug.Log("잔해 없음");
                break;
            case RuinState.BUILDING:
                Debug.Log("건물 잔해");
                break;
            case RuinState.IRON:
                Debug.Log("철골 잔해");
                break;
        }
    }

    private void Start()
    {
        Effect();
    }
}