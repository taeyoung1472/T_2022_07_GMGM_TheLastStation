using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAnimator : MonoBehaviour
{
    [SerializeField] private TrailAnimatorType type;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(type.ToString());
    }
    void Update()
    {
        
    }
}
public enum TrailAnimatorType
{
    Sit_1,
    Sit_2,
    Sit_Ground,
    Sit_Sad
}