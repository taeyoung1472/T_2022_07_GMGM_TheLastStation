using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Character : Character
{
    EnemyState curState;
    public override void Start()
    {
        base.Start();
        StartCoroutine(StateSystem());
    }
    IEnumerator StateSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
public enum EnemyState
{
    Idle,
    Chase,
}
