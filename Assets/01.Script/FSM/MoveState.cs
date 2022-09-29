using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State<MonsterFSM>
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
        Debug.Log("Move");
        _animator?.SetBool(hashMove, true);
        _agent.SetDestination(stateMachineClass.wayPoints[stateMachineClass.wayCount].position);
    }

    public override void OnUpdate(float dealtaTime)
    {
        Transform target = stateMachineClass.SearchEnemy();

        time += Time.deltaTime;

        if (stateMachineClass.wayCount >= stateMachineClass.wayPoints.Length)
        {
            stateMachineClass.wayCount = 0;
        }

        if (_agent.velocity == Vector3.zero)
        {
            _animator?.SetBool(hashMove, false);
        }
        else
        {
            _animator?.SetBool(hashMove, true);
        }
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            stateMachine.ChangeState<IdleState>();
        }
        //if (time > 2f)
        //{
        //    stateMachine.ChangeState<IdleState>();
        //}

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


    }
    public override void OnEnd()
    {
        stateMachineClass.wayCount++;
        _animator?.SetBool(hashMove, false);
        time = 0;
    }
}
