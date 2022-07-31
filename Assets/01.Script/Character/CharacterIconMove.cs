using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIconMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private void Start()
    {
        transform.SetParent(null);
    }
    private void Update()
    {
        transform.position = new Vector3(30, playerTransform.position.y, playerTransform.position.z);
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }
}
