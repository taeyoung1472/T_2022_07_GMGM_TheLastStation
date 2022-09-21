using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PurseState : State<MonsterFSM>
{
    private Animator _animator;


    //protected int hashMove = Animator.StringToHash("Move");
    //protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    private NavMeshAgent _agent;
    public override void OnAwake()
    {
        //_animator = stateMachineClass.GetComponent<Animator>();
        _agent = stateMachineClass.GetComponent<NavMeshAgent>();
    }
    public override void OnStart()
    {
        _agent?.SetDestination(stateMachineClass.target.position);
        //_animator?.SetBool(hashMove, true);
    }
    public override void OnUpdate(float dealtaTime)
    {
        Transform target = stateMachineClass.SearchEnemy();
        if (target)
        {
            _agent.SetDestination(stateMachineClass.target.position);

            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                Debug.Log("???");
                //_animator.SetFloat(hashMoveSpd, _agent.velocity.magnitude / _agent.speed, 0.1f, Time.deltaTime);
                return;
            }
        }
    }
    public override void OnEnd()
    {
        //_animator?.SetBool(hashMove, false);
        //_animator?.SetFloat(hashMoveSpd, 0);
        //_agent.ResetPath();
    }
}
