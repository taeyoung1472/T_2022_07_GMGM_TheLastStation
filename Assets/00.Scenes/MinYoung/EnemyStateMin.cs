using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMin : MonoBehaviour
{
    public enum eState
    {
        REST, WALK, PURSUE, ATTACK, DIE // �޽�, �ȱ�, �߰�, ����, ����
    };

    public eState stateName;

    private NavMeshAgent navMeshAgent;


    public Transform targetTrm;

    protected EnemyStateMin nextState;

public    float detectDist = 10.0f;
 public   float detectAngle = 30.0f;


    public Transform[] wayPoints = null;
    public int wayCount = 0;

    public LayerMask playerLayer;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        StartCoroutine(EnemyRoutine());
    }

    private IEnumerator EnemyRoutine()
    {
        while(true)
        {
            stateName = eState.WALK;
            yield return new WaitForSeconds(2f);
            wayCount++;
            stateName = eState.REST;
            yield return new WaitForSeconds(5f);
        }
    }

    private void Update()
    {
        CheckState();

        if (CanSeePlayer())
        {
            stateName = eState.PURSUE;
        }
    }

    /// <summary>
    /// ������Ʈ�� ���� ����Ǵ� �Լ�
    /// </summary>
    private void CheckState()
    {
        switch (stateName)
        {
            case eState.REST:
                Rest();
                //������ ������ �ϴ��ൿ
                break;
            case eState.WALK:
                Walk();
                //���� �ൿ
                break;
            case eState.PURSUE:
                //�����ൿ
                FollowTarget();
                break;
            case eState.ATTACK:
                Attack();
                //���� ���� �Լ�
                break;
            case eState.DIE:
                Die();
                //������ ���� �Լ�
                break;
            default:
                break;
        }
    }
    private void Rest()
    {
        //StartCoroutine(Rest());
    }
    /*
    private IEnumerator Rest()
    {
        Debug.Log("�޽� ��");
        yield return new WaitForSeconds(3f);
        stateName = eState.WALK;
        Debug.Log("�޽� ����");
    }*/
    private void Walk()
    {
        if (wayCount >= wayPoints.Length)
        {
            wayCount = 0;
        }

        if (navMeshAgent.velocity == Vector3.zero)
        {
            navMeshAgent.SetDestination(wayPoints[wayCount].position);
        }
    }

    public void FollowTarget()
    {
        Debug.Log("�ӱ���");
        navMeshAgent.SetDestination(targetTrm.position);
    }

 
    public bool CanSeePlayer()
    {
        //�����ȿ� ����
        //�ڽ�ĳ��Ʈ ���� �÷��̾ ������ ����
        Vector3 dir = targetTrm.position - transform.position;
        float angle = Vector3.Angle(dir, transform.forward);

        Debug.Log(angle);
        if (dir.magnitude < detectDist && angle < detectAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, playerLayer ) )
            {
                if (hit.transform == targetTrm)
                {
                  return true;
                }
            }
        }
         return false;
        //Vector3 direction = targetTrm.position - transform.position; // ���� �÷��̾ �ٶ󺸴� ����
        //float angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x) * Mathf.Rad2Deg;
        //bool isFront = Vector3.Dot(direction.normalized, transform.position.normalized) > 0f;
        //Debug.Log(Vector3.Dot(direction.normalized, transform.position.normalized));

        ////float angle = Vector3.Angle(direction.normalized, transform.forward);

        //if (direction.magnitude < detectDist && angle < detectAngle && isFront)
        //{
        //    StopAllCoroutines();
        //    return true;
        //}

        //return false;
    }
    public void Attack()
    {
        Debug.Log("����");
    }
    public void Die()
    {
        Debug.Log("����");
    }
}
