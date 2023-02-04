using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private EnemySpawn enemySpawn;

    private void Awake()
    {
        enemySpawn = GameObject.Find("/EnemySpawner").GetComponent<EnemySpawn>();
    }

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            enemySpawn.IncreaseEnemiesKilled();
            Destroy(gameObject);
        }
    }
}