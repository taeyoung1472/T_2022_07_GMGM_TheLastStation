using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControler : MonoBehaviour
{
    [SerializeField] private RectTransform focusRect;

    void Update()
    {
        focusRect.position = Input.mousePosition;
    }
}
