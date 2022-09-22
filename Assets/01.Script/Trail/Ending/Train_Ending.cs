using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Train_Ending : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip hornClip;
    [SerializeField] private AudioSource source;
    [SerializeField] private EndingUI endingUI;
    [SerializeField] private CinemachineVirtualCamera vcam;

    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip monsterClip;

    private float volume = 0;
    private float vcamVive = 0;
    public void Update()
    {
        source.volume = Mathf.Lerp(source.volume, volume, Time.deltaTime * 1f);
        float vive = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(vive, vcamVive, Time.deltaTime * 1f);
    }
    public void Drive()
    {
        animator.Play("Drive");
        volume = 1;
    }
    public void Shake()
    {
        vcamVive = 1;
    }
    public void ShakeStop()
    {
        vcamVive = 0;
    }
    public void ShakeUp()
    {
        vcamVive = 2;
    }

    public void VolDown()
    {
        volume = 0;
    }
    public void End()
    {
        endingUI.Close();
    }
    public void Horn()
    {
        AudioManager.Play(hornClip);
    }
    public void Shoot()
    {
        StartCoroutine(Brust());
    }

    public void Wing()
    {
        AudioManager.Play(monsterClip);
    }

    IEnumerator Brust()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.2f));
            AudioManager.Play(shootClip);

        }
    }
}
