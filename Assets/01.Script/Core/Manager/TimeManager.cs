using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float minPerTime;
    [SerializeField] private int min;
    [SerializeField] private int hour;
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
