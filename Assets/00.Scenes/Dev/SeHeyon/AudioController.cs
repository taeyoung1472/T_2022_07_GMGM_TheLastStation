using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioClip valueChangeSound;

    public void ChangeVolume(string str, float value)
    {
        audioMixer.SetFloat(str, value);
        AudioManager.Play(valueChangeSound);
    }
}
