using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Turret : Enviroment
{
    [SerializeField] private TurretBarrel[] barrels;
    [SerializeField] private Transform center;
    [SerializeField] private GameObject turretPanel;
    [SerializeField] private float delay;
    [SerializeField] private bool isControl = false;
    [SerializeField] private float rotSpeed = 5f;
    private bool isShooting = false;
    private float angle;
    private int idx = 0;
    public override void Start()
    {
        base.Start();
        StartCoroutine(Shoot());
    }
    public void Update()
    {
        if (isControl)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
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

    public void Controll()
    {
        turretPanel.SetActive(true);
        isControl = true;
    }

    public void ControllOut()
    {
        isControl = false;
        isShooting = false;
        turretPanel.SetActive(false);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitUntil(() => isShooting);
            barrels[idx].Shoot(delay);
            idx = (idx + 1) % barrels.Length;
            yield return new WaitForSeconds(delay);
        }
    }
}
