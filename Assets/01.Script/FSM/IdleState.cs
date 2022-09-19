using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State<MonsterFSM>
{
    private Animator _animator;
    private NavMeshAgent _agent;
    protected int hashMove = Animator.StringToHash("Move");
    protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    public float speed;

    public override void OnAwake()
    {
        _animator = stateMachineClass.GetComponent<Animator>();
        _agent = stateMachineClass.GetComponent<NavMeshAgent>();
        speed = _agent.speed;
    }
    public override void OnStart()
    {
        _animator?.SetBool(hashMove, false);
        _animator?.SetFloat(hashMoveSpd, 0);
        _agent.speed = 0f;
    }
    public override void OnUpdate(float dealtaTime)
    {
        Transform target = stateMachineClass.SearchEnemy();
        float time = 0f;
        time += Time.time;

        if (target)
        {
            if (stateMachineClass.getFlagAtk)
            {
                Debug.Log("아이들에서 어택으로 감");
                stateMachine.ChangeState<AttackState>();
            }
            else
            {
                Debug.Log("아이들에서 추적으로 감");
                stateMachine.ChangeState<PurseState>();
            }
        }
        else if (time > 2f)
        {
            Debug.Log("아이들에서 순찰로 감");
            stateMachine.ChangeState<MoveState>();
            time = 0f;
        }
    }
    public override void OnEnd()
    {
    }
}
