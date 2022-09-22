using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float minPerTime;
    private int min;
    private int hour;
    void Start()
    {
        StartCoroutine(TimeSystem());
    }
    IEnumerator TimeSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(minPerTime);
            min++;
            if(min >= 60)
            {
                hour++;
                min = 0;
            }
        }
    }
}
