using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSM : MonoBehaviour
{
    public StateMachine<MonsterFSM> enemyStateMachine;

    public LayerMask targetLayerMask; //����ȭ�� ���� 
    public float eyeSight;
    public Transform target;

    public float atkRange;

    
    public Transform[] wayPoints = null;
    public int wayCount = 0;

    void Start()
    {
        enemyStateMachine = new StateMachine<MonsterFSM>(this, new IdleState());
        enemyStateMachine.AddStateList(new MoveState());
    }

    void Update()
    {
        enemyStateMachine.Update(Time.deltaTime);
        Debug.Log(enemyStateMachine.getNowState);
    }
    public Transform SearchEnemy()
    {
        target = null;

        Collider[] findTargets = Physics.OverlapSphere(transform.position, eyeSight, targetLayerMask);

        if (findTargets.Length > 0)
        {
            target = findTargets[0].transform;
        }

        return target;
    }
    public bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }
            float distance = Vector3.Distance(transform.position, target.position);

            return (distance <= atkRange);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, eyeSight);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, atkRange);       
    }
        
}