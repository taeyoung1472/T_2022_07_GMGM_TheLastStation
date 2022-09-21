using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State<MonsterFSM>
{
    private Animator _animator;
    private NavMeshAgent _agent;
    //protected int hashMove = Animator.StringToHash("Move");
    //protected int hashMoveSpd = Animator.StringToHash("MoveSpd");


    private float time = 0f;
    public override void OnAwake()
    {
        //_animator = stateMachineClass.GetComponent<Animator>();
        _agent = stateMachineClass.GetComponent<NavMeshAgent>();
    }
    public override void OnStart()
    {
        //_animator?.SetBool(hashMove, false);
        //_animator?.SetFloat(hashMoveSpd, 0);
    }
    public override void OnUpdate(float dealtaTime)
    {
        Transform target = stateMachineClass.SearchEnemy();
        time += Time.deltaTime;
        //Debug.Log(time);


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
        else if (time > 3f)
        {
            Debug.Log("3초지남");
            Debug.Log("아이들에서 순찰로 감");
            stateMachine.ChangeState<MoveState>();
            time = 0f;
        }

    }
    public override void OnEnd()
    {
    }
}
