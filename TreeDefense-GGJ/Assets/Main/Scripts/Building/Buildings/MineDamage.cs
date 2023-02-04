using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDamage : MonoBehaviour
{
    private EnemyHealth enemy;
    [SerializeField] private int damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<EnemyHealth>();
            enemy.RemoveHealth(damage);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}