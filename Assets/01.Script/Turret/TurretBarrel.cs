using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretBarrel : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private Transform fireTrans;
    [SerializeField] private Transform bulletEjectPos;
    [SerializeField] private AudioClip fireClip;
    [SerializeField] private float barrelKnockbackPos;
    private float barrelOriginPos;

    public void Start()
    {
        barrelOriginPos = transform.localPosition.z;
    }

    public void Shoot(float dur)
    {
        fireParticle.Play();
        PoolManager.Instance.Pop(PoolType.TurretBullet).GetComponent<TurretBullet>().Set(fireTrans.position, fireTrans.rotation);
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(fireClip, Random.Range(0.9f, 1.1f));
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveZ(barrelOriginPos - barrelKnockbackPos, dur * 0.2f));
        seq.AppendCallback(() => {
            GameObject obj = PoolManager.Instance.Pop(PoolType.TurretShell);
            obj.GetComponent<TurretShell>().Set(bulletEjectPos.position, bulletEjectPos.rotation);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(bulletEjectPos.up * 5, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitCircle * 100f, ForceMode.Impulse);
        });
        seq.Append(transform.DOLocalMoveZ(barrelOriginPos, dur * 0.7f));
    }
}
