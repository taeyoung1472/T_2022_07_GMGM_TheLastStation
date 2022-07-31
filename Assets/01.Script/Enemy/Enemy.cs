using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageAble
{
    public Transform shootRay;
    [SerializeField]
    Transform TargetTransform;
    [SerializeField]
    Transform firePos;
    Vector3 trainPos;
    Vector3 playerPos;
    Vector3 move;

    Rigidbody enemyRigid;
    Animator enemyAni;

    bool isArrive;
    bool isMove;

    float fireelay = 0.3f;
    float lastFire;
    public GameObject projectile; //πﬂªÁ√º 
    RaycastHit hit;

    private void Start()
    {
        lastFire = 0;
        enemyAni = GetComponent<Animator>();
        enemyRigid = GetComponent<Rigidbody>();
        playerPos = transform.position;
        trainPos = TargetTransform.position;
    }
    private void FixedUpdate()
    {
        playerPos.x = Mathf.Lerp(transform.position.x, TargetTransform.position.x, Time.deltaTime);
        if (Mathf.Abs(transform.position.x - TargetTransform.position.x) < 0.1f)
        {
            isArrive = true;
        }
        if (!isArrive)
        {
            transform.position = Vector3.Lerp(playerPos, trainPos, Time.deltaTime / 3);
        }

        if (Physics.Raycast(shootRay.position, transform.forward, out hit, 10) && isArrive)
        {
            if (hit.transform.gameObject.CompareTag("Train"))
            {
                Attack();
            }
        }

        Debug.DrawRay(shootRay.position, transform.forward * 10, Color.red);
    }

    void Attack()
    {
    
        if (isMove)
        {
            float timer = 0;
            timer += Time.deltaTime;
            float i = Random.Range(0, 1f);
            if (i == 0)
            {
                move = new Vector3(5, 0, 0);
            }
            if (i == 1)
            {
                move = new Vector3(-5, 0, 0);
            }
            enemyAni.SetBool("IsAttack", false);
            enemyRigid.MovePosition(enemyRigid.position + move);
            if(timer >3f)
            {
                isMove=false;
            }
        }
        else
        {
            enemyAni.SetBool("IsAttack",true);
            ShootFire();  
            if(enemyAni.GetCurrentAnimatorStateInfo(0).IsName("FlyFire")&&enemyAni.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.99f)
            {
                isMove = true;
            }    
        }
    }
    void ShootFire()
    {
        if(Time.time>lastFire+fireelay)
        {
            lastFire = Time.time;
        Instantiate(projectile, firePos.position, Quaternion.identity);
        }
    }




    public void Damage(float amount, Vector3 orginPos = default, float force = 1)
    {

    }
}


