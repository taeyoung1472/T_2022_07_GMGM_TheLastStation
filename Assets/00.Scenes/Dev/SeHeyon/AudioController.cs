using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioClip valueChangeSound;
    [SerializeField] private Sprite[] sprites;

    [Header("Master")]
    [SerializeField] Image masterImage;
    [SerializeField] Slider masterSlider;

    [Header("BGM")]
    [SerializeField] Image bgmImage;
    [SerializeField] Slider bgmSlider;

    [Header("Effect")]
    [SerializeField] Image effectImage;
    [SerializeField] Slider effectSlider;

    private float timer;

    public void Start()
    {
        masterSlider.onValueChanged.AddListener(delegate { ChangeImageSprite(masterImage, masterSlider, "Master"); });
        bgmSlider.onValueChanged.AddListener(delegate { ChangeImageSprite(bgmImage, bgmSlider, "Bgm"); });
        effectSlider.onValueChanged.AddListener(delegate { ChangeImageSprite(effectImage, effectSlider, "Effect"); });
    }

    public void Update()
    {
        timer -= Time.deltaTime;
    }

    public void ChangeImageSprite(Image tgtImage, Slider tgtSlider, string str)
    {
        if(tgtSlider.value == -15)
        {
            tgtImage.sprite = sprites[0];
        }
        else if(tgtSlider.value <= -10f)
        {
            tgtImage.sprite = sprites[1];
        }
        else if(tgtSlider.value <= -5f)
        {
            tgtImage.sprite = sprites[2];
        }
        else
        {
            tgtImage.sprite = sprites[3];
        }

        audioMixer.SetFloat(str, tgtSlider.value);
        if(tgtSlider.value == -15) { audioMixer.SetFloat(str, -80); }

        if(timer < 0)
        {
            timer = 0.075f;
            AudioManager.Play(valueChangeSound);
        }
    }
}
