using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageAble
{

    int i=0;
    public Transform shootRay;
    [SerializeField]
    Transform TargetTransform;
    [SerializeField]
    Transform firePos;
    Vector3 trainPos;
    Vector3 playerPos;
    Vector3 move;
    Vector3 destination=Vector3.zero;

    Vector3 goPlace = Vector3.zero;
    Rigidbody enemyRigid;
    Animator enemyAni;

    [SerializeField]
    AudioClip fireSound;
    AudioSource enemyAudio;

    bool isArrive;
    bool isMove = false;
    bool isRandom = true;
    float timera = 0;
    float timer = 0;
    [SerializeField]
    float fireelay = 0.3f; //발사 지연 시간
    [SerializeField]
    float moveSpeed = 1f; // 움직이는 속도
    float lastFire;
    public GameObject projectile; //발사체 
    RaycastHit hit;
    
    private void Start()
    {
        isRandom = true;
        enemyAudio = GetComponent<AudioSource>();
        lastFire = 0;
        enemyAni = GetComponent<Animator>();
        enemyRigid = GetComponent<Rigidbody>();
        playerPos = transform.position;
        trainPos = TargetTransform.position;
    }
    private void Update()
    {
        print(destination);
        playerPos.x = Mathf.Lerp(transform.position.x, TargetTransform.position.x, Time.deltaTime);
        if (Mathf.Abs(transform.position.x - TargetTransform.position.x) < 0.1f)
        {
            isArrive = true;
        }
        if (!isArrive)
        {
            transform.position = Vector3.Lerp(playerPos, trainPos, Time.deltaTime * moveSpeed);
        }

        if (Physics.Raycast(shootRay.position, transform.forward, out hit, 10) && isArrive)
        {

            if (hit.transform.gameObject.CompareTag("Train"))
            {
                print("부딫힘");
                Attack();
            }
        }

        Debug.DrawRay(shootRay.position, transform.forward * 10, Color.red);
    }

    void Attack()
    {
 //움직일때 
        if (isMove)
        {
            if(isRandom )
            {
             i = Random.Range(0, 2);
                if(i==0)
                {
                    destination = transform.position + goPlace;
                }
                else if(i==1)
                {
                    destination = transform.position - goPlace;
                }
                isRandom = false;
                
            }
           timera+=Time.deltaTime;
            if(i==0)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);   
            }
            else if(i==1)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed); 
            }

            if (timera >= 3)
            {
                timera = 0;
                isMove = false;
                isRandom = true;
            }

        }
        // 공격할때 
        else if (!isMove)
        {
            enemyAni.SetBool("IsAttack", true);
            if (enemyAudio.isPlaying)
            {
                print("음악 키기");
                ShootFire();
            }
            else
            {

                ShootFire();
                enemyAudio.PlayOneShot(fireSound);

            }
        }
    }
    void ShootFire()
    {
        timer += Time.deltaTime;
        if (Time.time > lastFire + fireelay)
        {

            enemyAudio.PlayOneShot(fireSound);
            lastFire = Time.time;
            Instantiate(projectile, firePos.position, Quaternion.identity);

            if (timer >= 1.5f)
            {
                isMove = true;
                enemyAni.SetBool("IsAttack", false);
                Invoke("StopAudio", 1f);
                timer = 0;

            }
        }
    }
    void StopAudio()
    {
        enemyAudio.Stop();
    }




    public void Damage(float amount, Vector3 orginPos = default, float force = 1)
    {

    }
}


