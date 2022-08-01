using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    [SerializeField] private Image profileImage;
    CraftDataSO craftData;
    public void Set(CraftDataSO data)
    {
        craftData = data;
    }
}
