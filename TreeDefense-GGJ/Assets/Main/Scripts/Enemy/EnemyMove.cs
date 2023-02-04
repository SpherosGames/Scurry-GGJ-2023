using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int minDamage = 1;
    [SerializeField] private int maxDamage = 3;
    [SerializeField] private int defaultAttackTimer = 1;
    [SerializeField] private Nuts nuts;
    [SerializeField] private Animator animator;

    private bool canMove = true;
    private bool canAttack = false;

    private bool attackTimerOn = true;
    private float attackTimer;

    private int damage;

    private GameObject objectToDamage;

    private void Start()
    {
        nuts = GameObject.Find("Nuts").GetComponent<Nuts>();

        animator = GetComponent<Animator>();

        attackTimer = defaultAttackTimer;
    }

    private void FixedUpdate()
    {
        //Enemy Movement to the right.
        if (canMove)
        {
            transform.position += Vector3.right * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        //Enemy Attack
        if (canAttack)
        {
            animator.SetBool("IsCutting", true);

            if (attackTimerOn)
            {
                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0)
                {
                    damage = Random.Range(minDamage, maxDamage + 1);
                    attackTimer = defaultAttackTimer;
                    if (objectToDamage)
                    {
                        if (objectToDamage.CompareTag("Wall"))
                        {
                            objectToDamage.GetComponent<Wall>().RemoveHealth(damage);
                        }

                        if (objectToDamage.CompareTag("Turret"))
                        {
                            objectToDamage.GetComponent<Turret>().RemoveHealth(damage);
                        }

                        if (objectToDamage.CompareTag("Tree"))
                        {
                            nuts.RemoveNuts(damage);
                        }
                    }
                    else
                    {
                        canMove = true;
                        canAttack = false;
                    }
                }
            }
        }
        else
        {
            animator.SetBool("IsCutting", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            canMove = false;
            canAttack = true;
            objectToDamage = collision.gameObject;
        }

        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    print("Enemy in front of me!");
        //    collision.gameObject.GetComponent<EnemyMove>().canMove = false;
        //    canMove = false;
        //    canAttack = false;
        //    objectToDamage = null;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            canMove = true;
            canAttack = false;
            objectToDamage = null;
        }

        //if (collision.CompareTag("Enemy"))
        //{
        //    canMove = true;
        //    canAttack = false;
        //    objectToDamage = null;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false;
            canAttack = true;
            objectToDamage = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Turret"))
        {
            canMove = false;
            canAttack = true;
            objectToDamage = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true;
            canAttack = false;
            objectToDamage = null;
        }

        if (collision.gameObject.CompareTag("Turret"))
        {
            canMove = true;
            canAttack = false;
            objectToDamage = null;
        }
    }
}