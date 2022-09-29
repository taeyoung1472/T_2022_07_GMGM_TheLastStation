using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkStateMachine : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.GetComponent<MonsterFSM>().FsmManager.ChangeState<IdleState>();
    }
}
