using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretBarrel[] barrels;
    [SerializeField] private Transform center;
    [SerializeField] private float delay;
    [SerializeField] private bool isControl = false;
    [SerializeField] private float rotSpeed = 5f;
    float angle;
    Camera cam;
    int idx = 0;
    void Start()
    {
        cam = Camera.main;
        StartCoroutine(Shoot());
    }
    void Update()
    {
        if (isControl)
        {
            Vector3 pos = CameraController.Instance.GetMousePos();
            float angleGoal = Mathf.Atan2(pos.z - center.position.z, pos.y - center.position.y) * Mathf.Rad2Deg;
            if(angle < angleGoal)
            {
                angle += Time.deltaTime * rotSpeed;
            }
            else if (angle > angleGoal)
            {
                angle -= Time.deltaTime * rotSpeed;
            }
            angle = Mathf.Clamp(angle, -80, 80);
            center.eulerAngles = new Vector3(angle, 0, 0);
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            barrels[idx].Shoot(delay);
            idx = (idx + 1) % barrels.Length;
        }
    }
}
