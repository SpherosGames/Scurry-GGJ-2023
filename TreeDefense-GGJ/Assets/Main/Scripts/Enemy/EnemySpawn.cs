using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTimerDefault = 5f;
    [SerializeField] private int amountOfEnemysForWave = 3;

    private bool canSpawn = true;

    private bool spawnTimerOn = true;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnTimerDefault;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (spawnTimerOn && amountOfEnemysForWave > 0)
            {
                spawnTimer -= Time.deltaTime;

                if (spawnTimer <= 0)
                {
                    spawnTimer = spawnTimerDefault;
                    Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity, enemyParent);
                    amountOfEnemysForWave--;
                }
            }
        }
    }
}