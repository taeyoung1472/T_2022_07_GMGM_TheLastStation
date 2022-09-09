using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoSingleTon<UISoundManager>
{
    [SerializeField] private UISoundDataSO data;
    public UISoundDataSO Data { get { return data; } }

    public void PaperOpen()
    {
        AudioManager.Play(data.paperOpenSound);
    }

    public void PaperClose()
    {
        AudioManager.Play(data.paperCloseSound);
    }

    public void Open()
    {
        AudioManager.Play(data.openSound);
    }

    public void Close()
    {
        AudioManager.Play(data.closeSound);
    }

    public void CommandClick()
    {
        AudioManager.Play(data.clickSound);
    }

    public void SpeedChange()
    {
        AudioManager.Play(data.pressButtonSound);
    }

    public void Craft()
    {
        AudioManager.Play(data.craftSound);
    }

    public void LightClick()
    {
        AudioManager.Play(data.lightClickSound);
    }
}