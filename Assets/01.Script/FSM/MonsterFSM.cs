using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSM : MonoBehaviour
{

    protected StateMachine<MonsterFSM> fsmManager;
    public StateMachine<MonsterFSM> FsmManager => fsmManager;

    public Transform[] posTargets;
    public Transform posTarget = null;

    public int posTargetIdx = 0;

    public float eyeSight;

    public float atkRange;

    private FieldOfView _fov;

    public Transform target => _fov.FirstTarget;

    public Transform[] wayPoints = null;
    public int wayCount = 0;

    void Start()
    {
        fsmManager = new StateMachine<MonsterFSM>(this, new IdleState());
        fsmManager.AddStateList(new MoveState());
        fsmManager.AddStateList(new PurseState());
        fsmManager.AddStateList(new AttackState());

        _fov = GetComponent<FieldOfView>();
    }

    void Update()
    {
        fsmManager.Update(Time.deltaTime);
    }
    public Transform SearchEnemy()
    {
        return target;
    }
    public bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }
            float distance = Vector3.Distance(transform.position, target.position);

            return (distance <= atkRange);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, eyeSight);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, atkRange);       
    }
    public Transform SearchNextTargetPosition()
    {
        posTarget = null;

        if (posTargets.Length > 0)
        {
            posTarget = posTargets[posTargetIdx];
        }

        posTargetIdx = (posTargetIdx + 1) % posTargets.Length;

        return posTarget;
    }

}
