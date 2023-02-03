using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int minDamage = 1;
    [SerializeField] private int maxDamage = 3;
    [SerializeField] private int defaultAttackTimer = 1;

    private bool canMove = true;
    private bool canAttack = false;

    private bool attackTimerOn = true;
    private float attackTimer;

    private int damage;

    private void Start()
    {
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
            if (attackTimerOn)
            {
                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0)
                {
                    damage = Random.Range(minDamage, maxDamage + 1);
                    attackTimer = defaultAttackTimer;
                    print("The attack did " + damage + " damage");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            canMove = false;
            canAttack = true;
        }
    }
}