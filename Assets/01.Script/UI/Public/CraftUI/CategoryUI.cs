using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CategoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gridNameTmp;
    [SerializeField] private Transform content;

    [SerializeField] private ItemGrid itemGrid;

    public Transform Content { get { return content; } }

    public void Add(ItemDataSO data, Action onMouseDownAction)
    {
        ItemGrid grid = Instantiate(itemGrid, content);

        grid.Init(data);

        grid.RegistAction(onMouseDownAction);
    }
}
