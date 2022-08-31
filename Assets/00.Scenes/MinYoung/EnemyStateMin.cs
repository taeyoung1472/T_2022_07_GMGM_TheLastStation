using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMin : MonoBehaviour
{
    public enum eState
    {
        REST, WALK, PURSUE, ATTACK, DIE // 휴식, 걷기, 추격, 공격, 죽음
    };

    public eState stateName;

    private NavMeshAgent navMeshAgent;


    public Transform playerTrm;

    protected EnemyStateMin nextState;

    float detectDist = 10.0f;
    float detectAngle = 30.0f;


    public Transform[] wayPoints = null;
    public int wayCount = 0;

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
    /// 스테이트에 따라 실행되는 함수
    /// </summary>
    private void CheckState()
    {
        switch (stateName)
        {
            case eState.REST:
                R();
                //가만히 있을때 하는행동
                break;
            case eState.WALK:
                A();
                //Walk();
                //추적 행동
                break;
            case eState.PURSUE:
                //추적행동
                FollowTarget();
                break;
            case eState.ATTACK:
                Attack();
                //공격 실행 함수
                break;
            case eState.DIE:
                Die();
                //죽을떄 실행 함수
                break;
            default:
                break;
        }
    }
    private void R()
    {
        StartCoroutine(Rest());
    }
    private IEnumerator Rest()
    {
        Debug.Log("휴식 들어감");
        yield return new WaitForSeconds(3f);
        stateName = eState.WALK;
        Debug.Log("휴식 끝남");
    }
    private void A()
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
        Debug.Log("앙기모띠");
        navMeshAgent.SetDestination(playerTrm.position);
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = playerTrm.position - transform.position; // 내가 플레이어를 바라보는 방향
        float angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x) * Mathf.Rad2Deg;
        bool isFront = Vector3.Dot(direction.normalized, transform.position.normalized) > 0f;
        Debug.Log(Vector3.Dot(direction.normalized, transform.position.normalized));

        //float angle = Vector3.Angle(direction.normalized, transform.forward);

        if (direction.magnitude < detectDist && angle < detectAngle && isFront)
        {
            StopAllCoroutines();
            return true;
        }

        return false;
    }
    public void Attack()
    {
        Debug.Log("공격");
    }
    public void Die()
    {
        Debug.Log("죽음");
    }
}
