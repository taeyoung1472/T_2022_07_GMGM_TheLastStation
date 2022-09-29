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
            Debug.Log("어택");
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
        //애니메이터 비헤비어트리에서 exit함수에서 아이들로 체인지
        //stateMachine.ChangeState<IdleState>();
    }
}
