using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TurretShell : PoolAbleObject
{
    MeshRenderer meshRenderer;
    Color stdColor;
    public override void Init_Pop()
    {
        if(meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
            stdColor = meshRenderer.material.color;
        }
        meshRenderer.material.color = stdColor;
        StartCoroutine(Wait());
        Fade();
    }

    public override void Init_Push()
    {

    }
    private void Fade()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        seq.Append(meshRenderer.material.DOColor(new Color(stdColor.r, stdColor.g, stdColor.b, 0f), 1));
    }
    public void Set(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        PoolManager.Instance.Push(PoolType.TurretShell, gameObject);
    }
}
