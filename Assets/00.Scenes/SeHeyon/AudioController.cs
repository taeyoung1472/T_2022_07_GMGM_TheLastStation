using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    Image soundimage;
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    Slider audioSlider;
    [SerializeField]
    Sprite[] sprites;
    void Start()
    {
        if (audioSlider.value == -14)
            soundimage.sprite = sprites[0];
        else if (-14 < audioSlider.value && audioSlider.value < -7)
            soundimage.sprite = sprites[1];
        else if (-7 <= audioSlider.value && audioSlider.value < 0)
            soundimage.sprite = sprites[2];
        else if (audioSlider.value == 7)
            soundimage.sprite = sprites[3];
    }

    // Update is called once per frame
    void Update()
    {
        
        if (audioSlider.value == -14)
            soundimage.sprite = sprites[0];
        else if (-14 < audioSlider.value && audioSlider.value < -7)
            soundimage.sprite = sprites[1];
        else if (-7 <= audioSlider.value && audioSlider.value < 0)
            soundimage.sprite = sprites[2];
        else if (audioSlider.value == 7)
            soundimage.sprite = sprites[3];
    }
    public void SoundControl()
    {
        float sound = audioSlider.value;
        if (sound == -14) audioMixer.SetFloat("SoundSlider", -80);
        else audioMixer.SetFloat("SoundSlider", sound);
    }
}
