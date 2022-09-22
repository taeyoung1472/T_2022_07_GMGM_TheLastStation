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
        StopAllCoroutines();
        StartCoroutine(TimePool());
    }
    public void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private IEnumerator TimePool()
    {
        yield return new WaitForSeconds(5);
        PoolManager.Instance.Push(PoolType, gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {

    }
}
