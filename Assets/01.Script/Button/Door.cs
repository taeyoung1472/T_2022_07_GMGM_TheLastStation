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
    [SerializeField] private Sprite[] btnSprites;
    [SerializeField] private GameObject doorBtn;

    [SerializeField] private ItemDataSO key;

    public void Control()
    {
        if (!isLock)
        {
            if (isOpen)
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
            }
            else
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }
            isOpen = !isOpen;
        }
        else
        {
            if (InventoryHandler.Instance.ReturnAmout(key) >= 1)
            {
                isLock = false;
                Control();
                InventoryHandler.Instance.Use(key, 1);
                doorBtn.GetComponent<SpriteRenderer>().sprite = btnSprites[1];
            }
            else
                print("ø≠ºË « ø‰«‘");
        }
    }
}
