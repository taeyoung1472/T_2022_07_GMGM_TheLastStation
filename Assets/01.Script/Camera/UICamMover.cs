using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICamMover : MonoSingleTon<CameraController>, IPointerDownHandler, IPointerUpHandler
{
    [Header("카메라 이동")]
    [SerializeField] private float camLimitHorizontal;
    [SerializeField] private float camLimitVertical;
    [SerializeField] private float camMoveSpeed;
    private float moveSpeed;
    private float moveGoal;
    private bool isBtnDown = false;

    [SerializeField]Camera cam;

    private void Start()
    {
        cam.transform.position = new Vector3(60, 3, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
        moveSpeed = 0f;
    }

    public void Move(float moveDirX = 0, float moveDirY = 0)
    {
        moveGoal = camMoveSpeed;
        moveSpeed = Mathf.Lerp(moveSpeed, moveGoal, Time.deltaTime * 0.5f);
        cam.transform.position += new Vector3(0f, moveDirY * moveSpeed, moveDirX * moveSpeed);
    }


    public void LeftBtn()
    {
        StartCoroutine(OnDownLeftBtn());
    }
    private IEnumerator OnDownLeftBtn()
    {
        while(cam.transform.position.z >= -camLimitHorizontal && isBtnDown)
        {
            yield return new WaitForSeconds(0.02f);
            Move(-1f);
        }
    }
    public void RightBtn()
    {
        StartCoroutine(OnDownRightBtn());
    }
    private IEnumerator OnDownRightBtn()
    {
        while (cam.transform.position.z <= camLimitHorizontal && isBtnDown)
        {
            yield return new WaitForSeconds(0.02f);
            Move(1f);
        }
    }

}
