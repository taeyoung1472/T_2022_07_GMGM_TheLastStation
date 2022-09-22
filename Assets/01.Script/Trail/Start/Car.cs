using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip doorClip;
    [SerializeField] private AudioSource engineSource;
    float enginePitchGoal;
    Vector3 prevPos;
    bool checkPrev = false;
    public void Start()
    {
        StartCoroutine(engineSoundSystem());   
    }
    public void Update()
    {
        engineSource.pitch = Mathf.Lerp(engineSource.pitch, enginePitchGoal, Time.deltaTime * 2.5f);
    }
    public void Drive()
    {
        animator.Play("Drive");
    }
    
    public void CloseDoor()
    {
        PlaySound(doorClip);
    }

    public void End()
    {
        JsonManager.Data.hasSawTrail = true;
        JsonManager.Save();
        GameManager.Instance.LoadGame();
    }

    IEnumerator engineSoundSystem()
    {
        while (true)
        {
            if (!checkPrev)
            {
                prevPos = transform.position;
            }
            else
            {
                if ((transform.position - prevPos).magnitude == 0)
                {
                    engineSource.volume = 0;
                }
                else
                {
                    engineSource.volume = 1;
                }
                float tgtPitch = (transform.position - prevPos).magnitude * 4f;
                if(tgtPitch > 1.5f)
                {
                    tgtPitch = 1.5f;
                }
                enginePitchGoal = tgtPitch;
            }
            checkPrev = !checkPrev;
            yield return new WaitForSeconds(0.025f);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        AudioManager.Play(clip);
    }
}
