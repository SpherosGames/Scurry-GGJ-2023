using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}