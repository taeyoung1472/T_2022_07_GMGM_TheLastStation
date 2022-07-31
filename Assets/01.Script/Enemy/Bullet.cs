using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
     Transform targetTransform;
    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Train").transform;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position=  Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Train"))
        {

            Destroy(gameObject);
        }

    }
}
