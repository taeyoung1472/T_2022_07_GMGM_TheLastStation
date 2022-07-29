using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageAble
{
    [SerializeField]
    Transform trainT;
    Vector3 trainPos;
    Vector3 playerPos;
    Rigidbody enemyRigid;
    bool isArrive;
    public GameObject projectile; //πﬂªÁ√º 
    RaycastHit hit;

    private void Start()
    {
        enemyRigid = GetComponent<Rigidbody>();
        playerPos = transform.position;
        trainPos = trainT.position;
    }
    private void Update()
    {
        playerPos.x = Mathf.Lerp(transform.position.x, trainT.position.x, Time.deltaTime);
        if(Mathf.Abs(transform.position.x-trainT.position.x)<0.1f)
        {
            isArrive = true;
        }
        if(!isArrive)
        {
        transform.position = Vector3.Lerp(playerPos, trainPos, Time.deltaTime/3); 
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit,10)&&isArrive)
        {
            if(hit.transform.gameObject.CompareTag("Train"))
            {
               StartCoroutine(Attack());
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
    }
   IEnumerator Attack()
    {
        WaitForSeconds wait =new WaitForSeconds(3f);
        Vector3 enemyMove = Vector3.zero;
        float random;
        while(true)
        {
            random = Random.Range(0f, 1f);
            switch(random)
            {
                case 0:
                    enemyMove = new Vector3(4,0,0);
                    break;
                case 1:
                    enemyMove= new Vector3(-4, 0, 0);
                    break;
            }
            print(random);
            enemyRigid.MovePosition(enemyRigid.position+enemyMove);
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return wait;
        }
         
    }
    public void Damage(float amount, Vector3 orginPos = default, float force = 1)
    {
        
    }

}
