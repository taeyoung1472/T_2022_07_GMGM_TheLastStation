using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    /// <summary> 데미지 주기 </summary>
    public void Damage(float amount, Vector3 orginPos = default(Vector3), float force = 1);
}
