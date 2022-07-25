using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Background : MonoBehaviour
{
    [SerializeField] private BackgroundPare[] backgroundPares;
    private Dictionary<BackgroundType, GameObject[]> backgroundPareInfo = new Dictionary<BackgroundType, GameObject[]>();
    private GameObject prevObject;
    public void Awake()
    {
        foreach (var bg in backgroundPares)
        {
            backgroundPareInfo.Add(bg.backgroundType, bg.backgrounds);
        }
    }
    public void Active(BackgroundType type)
    {
        if(prevObject != null)
        {
            prevObject.SetActive(false);
        }
        GameObject obj = backgroundPareInfo[type][Random.Range(0, backgroundPareInfo[type].Length)];
        obj.SetActive(true);
        prevObject = obj;
    }
}
[Serializable]
public class BackgroundPare
{
    public BackgroundType backgroundType;
    public GameObject[] backgrounds;
}