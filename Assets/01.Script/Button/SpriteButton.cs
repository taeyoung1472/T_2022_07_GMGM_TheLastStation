using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] private UnityEvent<Character> buttonEvent;
    [Range(0, 20)][SerializeField] private float duration;
    [SerializeField] private Transform slider;
    [SerializeField] private Transform slider_Fill;
    [SerializeField] private bool isReset = false;
    Character usingCharacter;
    public Character UsingCharacter { get { return usingCharacter; } set { usingCharacter = value; } }
    public float Duration { get { return duration; } set { duration = value; } }
    private float curDur;
    private bool isUsing;

    public void Start()
    {
        curDur = duration;
        if(curDur == 0)
        {
            slider.gameObject.SetActive(false);
        }
        slider_Fill = slider.Find("Fill");
    }

    public void Update()
    {
        DisplaySlide();
        if (isUsing)
        {
            curDur -= Time.deltaTime;
            if (curDur < 0)
            {
                buttonEvent?.Invoke(usingCharacter);
                print($"{usingCharacter.Data.name} 이가 {name}을 작동시킴");
                usingCharacter.CompleteAct();
                curDur = duration;
                isUsing = false;
                UsingCharacter = null;
            }
        }
    }

    private void DisplaySlide()
    {
        if(duration == 0) return;
        slider_Fill.transform.localScale = new Vector3(curDur / duration, 1, 1);
    }

    public void UseStart()
    {
        if (isUsing) return;
        print($"{usingCharacter.Data.name} 이가 {name}을 작동시키는중");
        if (isReset)
        {
            curDur = duration;
        }
        isUsing = true;
    }

    public void UseCancel()
    {
        if (isReset)
        {
            curDur = duration;
        }
        UsingCharacter = null;
        isUsing = false;
    }
}
