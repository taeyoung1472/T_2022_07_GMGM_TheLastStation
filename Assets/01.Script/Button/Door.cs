using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public bool IsHaveKey = false;
    private bool isOpen = false;
    [SerializeField] private bool isLock = false;

    public void Control()
    {
        if (!isLock)
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            }
            else
            {
                transform.DORotate(new Vector3(0, 90, 0), 0.5f);
            }
        }
        else
        {
            if (IsHaveKey)
            {
                isLock = false;
                Control();
            }
            else
                print("ø≠ºË « ø‰«‘");
        }
    }
}
