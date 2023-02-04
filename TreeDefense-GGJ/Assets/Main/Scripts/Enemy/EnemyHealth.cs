using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private EnemySpawn enemySpawn;
    [SerializeField] private Nuts nut;
    [SerializeField] private int minNut;
    [SerializeField] private int maxNut;

    private int nutDropAmount;

    private void Awake()
    {
        enemySpawn = GameObject.Find("/EnemySpawner").GetComponent<EnemySpawn>();

        nut = GameObject.Find("/Nuts").GetComponent<Nuts>();
    }

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            nutDropAmount = Random.Range(minNut, maxNut + 1);
            nut.AddNuts(nutDropAmount);
            print(nutDropAmount);
            enemySpawn.IncreaseEnemiesKilled();
            Destroy(gameObject);
        }
    }
}
