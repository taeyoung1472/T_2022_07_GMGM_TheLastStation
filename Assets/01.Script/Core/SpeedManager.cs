using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] private BackgroundManager backgroundManager;
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private AudioSource engineSource;
    [SerializeField] private AudioSource railSource;

    void Update()
    {
        engineSource.pitch = (backgroundManager.Speed / 70f) + 0.5f;

        railSource.volume = (backgroundManager.Speed / 20f) > 1f ? 1f : (backgroundManager.Speed / 20f);

        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = (backgroundManager.Speed / 70f) * 2;
    }
}
