using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region 카메라 이동
    [Header("카메라 이동")]
    [SerializeField] private Vector2 camLimitScale;
    [SerializeField] private Vector2 camLimitCenter;
    [SerializeField] private float camMoveSpeed;
    private Vector3 startSwipePos;
    private Vector2 moveDir;
    private float moveSpeed;
    private float moveGoal;
    private bool isSwiping;
    #endregion

    #region 카메라 줌
    [Header("카메라 줌")]
    [SerializeField] private float[] zoomValue;
    [SerializeField] private LayerMask zoomCull;
    [SerializeField] private LayerMask zoomOutCull;
    private float zoomGoal = 60;
    private int zoomIndex = 4;
    #endregion

    #region Raycast 관련
    [Header("Raycast")]
    [SerializeField] private LayerMask rayMask;
    [SerializeField] private LayerMask rayGroundMask;
    [SerializeField] private LayerMask mouseCheckMask;
    public NavMeshAgent agent;
    RaycastHit hit;
    #endregion
    Camera cam;
    public void Start()
    {
        cam = Camera.main;
        StartCoroutine(ZoomInput());
    }
    public void Update()
    {
        Zoom();
        Move();
        InputHandle();
    }

    private void InputHandle()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootRay();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isSwiping = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isSwiping = false;
        }
    }

    private void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, rayMask))
        {
            if (hit.transform.CompareTag("Character"))
            {
                CharacterManager.Instance.ControllCharacter(hit.transform.GetComponent<Character>());
            }
            else if (hit.transform.CompareTag("MouseCheck"))
            {
                CharacterManager.Instance.Controll(ControllType.Move, GroundPos(hit));
            }
            else if (hit.transform.CompareTag("Button"))
            {
                CharacterManager.Instance.Controll(ControllType.Act, GroundPos(hit), hit.transform.GetComponent<SpriteButton>());
            }
        }
    }

    private Vector3 GroundPos(RaycastHit hit)
    {
        RaycastHit hitCheck;
        if (Physics.Raycast(hit.point, Vector3.down, out hitCheck, 100, rayGroundMask))
        {
            return hitCheck.point;
        }
        return Vector3.zero;
    }

    private void Move()
    {
        if (isSwiping)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            moveDir.x = mouseX * -5;
            moveDir.y = mouseY * -5;

            moveSpeed = camMoveSpeed;
        }
        else
        {
            Vector2 mouseViewPort = cam.ScreenToViewportPoint(Input.mousePosition);

            moveDir.x = mouseViewPort.x < 0.05f ? -1 : mouseViewPort.x > 0.95f ? 1 : 0;
            moveDir.y = mouseViewPort.y < 0.05f ? -1 : mouseViewPort.y > 0.95f ? 1 : 0;

            if (moveDir.magnitude != 0)
            {
                moveGoal = camMoveSpeed;
            }
            else
            {
                moveGoal = 0;
            }

            moveSpeed = Mathf.Lerp(moveSpeed, moveGoal, Time.deltaTime * 2.5f);
        }

        cam.transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        float h = Mathf.Clamp(cam.transform.position.z, camLimitCenter.x - camLimitScale.x * 0.5f, camLimitCenter.x + camLimitScale.x * 0.5f);
        float v = Mathf.Clamp(cam.transform.position.y, camLimitCenter.y - camLimitScale.y * 0.5f, camLimitCenter.y + camLimitScale.y * 0.5f);

        cam.transform.position = new Vector3(cam.transform.position.x, v, h);
    }

    private void Zoom()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomGoal, Time.deltaTime * 5);
    }

    private IEnumerator ZoomInput()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetAxisRaw("Mouse ScrollWheel") != 0);
            float temp = -Input.GetAxisRaw("Mouse ScrollWheel");
            if (temp > 0) zoomIndex++;
            else zoomIndex--;
            zoomIndex = Mathf.Clamp(zoomIndex, 0, zoomValue.Length - 1);
            zoomGoal = zoomValue[zoomIndex];
            if(zoomIndex < 3)
            {
                cam.cullingMask = zoomCull;
            }
            else
            {
                cam.cullingMask = zoomOutCull;
            }
            yield return null;
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(0, camLimitCenter.y, camLimitCenter.x), new Vector3(0, camLimitScale.y, camLimitScale.x));
    }
#endif
}
