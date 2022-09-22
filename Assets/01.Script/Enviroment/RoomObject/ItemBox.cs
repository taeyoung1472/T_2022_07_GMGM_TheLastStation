using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, IObjects
{
    public void Effect(int roomWidth = 1)
    {
        switch(Random.Range(0,2))
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                break;
        }
    }

    private void Start()
    {
        Effect();
    }
}
