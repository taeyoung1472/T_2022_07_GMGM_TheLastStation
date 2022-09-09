using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private static PoolManager poolManager;
    private static PoolManager PoolManager { get { if (poolManager == null) { poolManager = PoolManager.Instance; } return poolManager; } }
    public static void Play(AudioClip clip, float pitch = 1f, float volume = 1f)
    {
        PoolManager.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(clip, pitch, volume);
    }
}
