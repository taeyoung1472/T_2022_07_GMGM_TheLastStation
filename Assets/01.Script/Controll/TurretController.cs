using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private RectTransform focusRect;

    //Camera cam;
    void Start()
    {
        //cam = Camera.main;
    }
    void Update()
    {
        focusRect.position = Input.mousePosition;
    }
}
