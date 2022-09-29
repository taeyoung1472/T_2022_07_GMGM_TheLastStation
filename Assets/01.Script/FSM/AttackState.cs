using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<MonsterFSM>
{
    private Animator _animator;

    protected int hashAttack = Animator.StringToHash("Attack");

    public override void OnAwake()
    {
        _animator = stateMachineClass.GetComponentInChildren<Animator>();
    }

    public override void OnStart()
    {
        if (stateMachineClass.getFlagAtk)
        {
            Debug.Log("����");
            _animator?.SetTrigger(hashAttack);
        }
        else
        {
            stateMachine.ChangeState<PurseState>();
        }
    }

    public override void OnUpdate(float deltaTime)
    {

    }

    public override void OnEnd()
    {
        //�ִϸ����� ������Ʈ������ exit�Լ����� ���̵�� ü����
        //stateMachine.ChangeState<IdleState>();
    }
}
