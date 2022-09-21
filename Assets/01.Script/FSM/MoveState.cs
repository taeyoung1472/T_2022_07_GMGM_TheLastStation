using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State<MonsterFSM>
{
    //private Animator _animator;

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
        //_animator?.SetBool(hashMove, true);
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
            _agent.SetDestination(stateMachineClass.wayPoints[stateMachineClass.wayCount].position);
            Debug.Log(stateMachineClass.wayCount);
            //stateMachineClass.wayCount++;
        }

        else if (target)
        {
            if (stateMachineClass.getFlagAtk)
            {
                Debug.Log("���꿡�� �������� ��");
                //stateMachine.ChangeState<AttackState>();
            }
            else
            {
                Debug.Log("���꿡�� �������� ��");
                stateMachine.ChangeState<PurseState>();
            }
        }
        else if(time > 2f)
        {
            Debug.Log("2������");
            Debug.Log("���꿡�� ���̵�� ��");
            stateMachine.ChangeState<IdleState>();
        }



    }
    public override void OnEnd()
    {
        stateMachineClass.wayCount++;
    }
}
