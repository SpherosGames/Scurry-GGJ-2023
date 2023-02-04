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
        Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("Horizontal") < -0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}