using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : PoolAbleObject
{
    [SerializeField] private float speed;
    public override void Init_Pop()
    {

    }

    public override void Init_Push()
    {

    }
    public void Set(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }
    public void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public void OnCollisionEnter(Collision collision)
    {

    }
}
