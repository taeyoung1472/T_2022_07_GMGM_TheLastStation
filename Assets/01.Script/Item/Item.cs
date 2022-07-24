using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO data;
    public int dropableCount;
}
