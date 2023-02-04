using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float[] spawnTimerDefault;
    [SerializeField] private float amountOfWaves;
    [SerializeField] private int[] amountOfEnemysForWave;

    private bool canSpawn = true;

    private bool spawnTimerOn = true;
    private float spawnTimer;

    private int currentWaveNum;

    private void Start()
    {
        spawnTimer = spawnTimerDefault[currentWaveNum];
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (spawnTimerOn && amountOfEnemysForWave[currentWaveNum] > 0)
            {
                spawnTimer -= Time.deltaTime;

                if (spawnTimer <= 0)
                {
                    spawnTimer = spawnTimerDefault[currentWaveNum];
                    Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity, enemyParent);
                    amountOfEnemysForWave[currentWaveNum]--;
                }
            }
        }

        if (amountOfEnemysForWave[currentWaveNum] <= 0)
        {
            currentWaveNum++;
            if (currentWaveNum >= amountOfWaves)
            {
                print("Game won!");
            }
        }
    }
}