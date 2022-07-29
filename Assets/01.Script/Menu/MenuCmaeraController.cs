using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCmaeraController : MonoBehaviour
{
    [SerializeField] private float senservity;
    private Camera cam;
    private Vector3 originPos;
    public void Awake()
    {
        originPos = transform.position;
        cam = Camera.main;
    }
    public void Update()
    {
        Vector2 viewPort = cam.ScreenToViewportPoint(Input.mousePosition);
        transform.position = originPos + (Vector3)viewPort * senservity;
    }
}
