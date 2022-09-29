using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PurseState : State<MonsterFSM>
{
    private Animator _animator;


    protected int hashMove = Animator.StringToHash("Move");

    private NavMeshAgent _agent;
    public override void OnAwake()
    {
        _animator = stateMachineClass.GetComponent<Animator>();
        _agent = stateMachineClass.GetComponent<NavMeshAgent>();
    }
    public override void OnStart()
    {
        Debug.Log("Purse");
        _agent?.SetDestination(stateMachineClass.target.position);
        _animator?.SetBool(hashMove, true);
    }
    public override void OnUpdate(float dealtaTime)
    {
        Transform target = stateMachineClass.SearchEnemy();
        if (target)
        {
            _agent.SetDestination(stateMachineClass.target.position);

            if (stateMachineClass.getFlagAtk)
            {
                Debug.Log("æÓ≈√±Ú≤Ù¥œ±Ó");
                stateMachine.ChangeState<AttackState>();
            }
            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                Debug.Log("???");
                return;
            }
          
        }
    }
    public override void OnEnd()
    {
        _animator?.SetBool(hashMove, false);
        _agent.ResetPath();
    }
}
