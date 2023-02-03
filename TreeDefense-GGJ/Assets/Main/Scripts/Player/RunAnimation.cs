using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}