using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State<MonsterFSM>
{
    private Animator _animator;
    private NavMeshAgent _agent;

    protected int hashMove = Animator.StringToHash("Move");

    private float time = 0f;
    public override void OnAwake()
    {
        _animator = stateMachineClass.GetComponent<Animator>();
        _agent = stateMachineClass.GetComponent<NavMeshAgent>();
    }
    public override void OnStart()
    {
        Debug.Log("Idle");
        _animator?.SetBool(hashMove, false);
    }
    public override void OnUpdate(float dealtaTime)
    {
        Transform target = stateMachineClass.SearchEnemy();
        time += Time.deltaTime;

        if (target)
        {
            if (stateMachineClass.getFlagAtk)
            {
                stateMachine.ChangeState<AttackState>();
            }
            else
            {
                stateMachine.ChangeState<PurseState>();
            }
        }
        if (time > 3f)
        {
            stateMachine.ChangeState<MoveState>();
            time = 0f;
        }

    }
    public override void OnEnd()
    {
    }
}
