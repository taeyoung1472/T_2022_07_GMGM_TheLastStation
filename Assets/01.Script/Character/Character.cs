using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamageAble
{
    #region 에니메이션 관련
    Animator animator;
    readonly int MoveHash = Animator.StringToHash("Move");
    private float animH;
    #endregion

    #region 이동 관련
    NavMeshAgent agent;
    private Vector3 moveDir;
    private float speed;
    private bool isAttaching = false;
    #endregion

    Action actAction;

    [SerializeField] private CharacterData data;
    public CharacterData Data { get { return data; } }

    SpriteButton usingButton = null;

    SpriteButton attachingButton = null;

    public SpriteButton UsingButton { get { return usingButton; } set { usingButton = value; } }

    public void Awake()
    {
        animator = transform.GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        speed = data.moveSpeed;
    }

    public void Update()
    {
        Animate();
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (isAttaching)
        {
            if (Vector3.Distance(agent.destination, transform.position) < 1 + agent.stoppingDistance)
            {
                isAttaching = false;
                if(attachingButton != null)
                {
                    if (attachingButton.UsingCharacter != null) return;
                    usingButton = attachingButton;
                    if (usingButton.UsingCharacter == null)
                    {
                        usingButton.UsingCharacter = this;
                    }
                    attachingButton = null;
                    animator.SetBool("Work", true);
                    animator.Play("Work");
                    actAction?.Invoke();
                }
            }
        }
    }

    private void Animate()
    {
        animH = Mathf.Lerp(animH, agent.velocity.x == 0 ? 0 : 1, Time.deltaTime * 5f);
        animator.SetBool(MoveHash, Vector3.Distance(agent.destination, transform.position) > 0.25 + agent.stoppingDistance);
    }

    public void Move(Vector3 dir)
    {
        agent.SetDestination(dir);
        actAction = null;
        isAttaching = true;
    }

    public void Act(Action callBackAction, SpriteButton button)
    {
        actAction = callBackAction;
        attachingButton = button;
    }

    public void Attack(Vector3 dir, SpriteButton button)
    {
        if(!(button is AttackButton))
        {
            Debug.LogError("이버튼은 공격용 버튼이 아님");
            return;
        }
        Character target = button.GetComponent<AttackButton>().Character;
        bool isRight = dir.z > transform.position.z;
        print($"{target.Data.name}을 공격함");
    }

    public void CancelAct()
    {
        attachingButton = null;
        UsingButton = null;
        animator.SetBool("Work", false);
    }

    public void CompleteAct()
    {
        attachingButton = null;
        UsingButton = null;
        animator.SetBool("Work", false);
    }

    public void Damage(float amount, Vector3 orginPos = default, float force = 1)
    {
    }
}
