using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    public void Control()
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
}
