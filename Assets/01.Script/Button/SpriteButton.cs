using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] private UnityEvent<Character> buttonEvent;
    [Range(0, 20)][SerializeField] private float duration;
    [SerializeField] private Transform slider;
    private Transform slider_Fill;
    [SerializeField] private bool isReset = false;
    Character usingCharacter;
    public Character UsingCharacter { get { return usingCharacter; } set { usingCharacter = value; } }
    public float Duration { get { return duration; } set { duration = value; } }
    private float curDur;
    private bool isUsing;

    AudioSource audioSource;
    float vol;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.volume = 0f;
        audioSource.outputAudioMixerGroup = GameManager.Instance.EffectGroup;
        audioSource.clip = UISoundManager.Instance.Data.actSound;
        audioSource.Play();
        curDur = duration;
        if(curDur == 0)
        {
            slider.gameObject.SetActive(false);
        }
        slider_Fill = slider.Find("Fill");
    }

    public void Update()
    {
        audioSource.volume = Mathf.Lerp(audioSource.volume, vol, Time.deltaTime * 2f);
        DisplaySlide();
        if (isUsing)
        {
            curDur -= Time.deltaTime;
            if (curDur < 0)
            {
                buttonEvent?.Invoke(usingCharacter);
                print($"{usingCharacter.Data.name} 이가 {name}을 작동시킴");
                vol = 0;
                usingCharacter.CompleteAct();
                curDur = duration;
                isUsing = false;
                UsingCharacter = null;
                Color color;
                ColorUtility.TryParseHtmlString("#545454FF", out color);
                gameObject.GetComponent<SpriteRenderer>().color = color;
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
        Color color;
        ColorUtility.TryParseHtmlString("#FF8000FF", out color);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        vol = 1;
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
        Color color;
        ColorUtility.TryParseHtmlString("#545454FF", out color);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        vol = 0;
        UsingCharacter = null;
        isUsing = false;
    }
}
