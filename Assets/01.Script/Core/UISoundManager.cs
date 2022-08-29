using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoSingleTon<UISoundManager>
{
    [SerializeField] private UISoundDataSO data;
    public UISoundDataSO Data { get { return data; } }

    public void PaperOpen()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.paperOpenSound);
    }

    public void PaperClose()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.paperCloseSound);
    }

    public void Open()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.openSound);
    }

    public void Close()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.closeSound);
    }

    public void CommandClick()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.clickSound);
    }

    public void SpeedChange()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.pressButtonSound);
    }

    public void Craft()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.craftSound);
    }

    public void LightClick()
    {
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(data.lightClickSound);
    }
}