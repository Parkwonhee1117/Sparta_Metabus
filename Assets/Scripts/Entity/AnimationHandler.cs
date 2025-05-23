using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int _isMoving = Animator.StringToHash("IsMove");

    protected Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void Move(Vector2 obj)
    {
        if(animator != null)
        {
            animator.SetBool(_isMoving, obj.magnitude > 0.5f);
        }
        else
        {
            Debug.LogError("Animator is null");
        }
        
    }
}
