using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float[] spawnTimerDefault;
    [SerializeField] private float amountOfWaves;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int[] amountOfEnemysForWave;
    [SerializeField] private TMP_Text waveInfoText;
    [SerializeField] private BirdInteraction bird;

    private int amountOfEnemiesKilled;
    private int currentAmountOfEnemiesSpawned;
    private int totalEnemiesCurrentWave;

    private bool canSpawn = true;

    private bool spawnTimerOn = true;
    private float spawnTimer;

    private int currentWaveNum;

    private bool doOnce = true;

    private float timeBetweenWavesTimer;

    private int nutsPerWave;

    private bool startGame;

    private void Start()
    {
        spawnTimer = spawnTimerDefault[currentWaveNum];
        totalEnemiesCurrentWave = amountOfEnemysForWave[currentWaveNum];
        timeBetweenWavesTimer = timeBetweenWaves;
    }

    private void Update()
    {
        if (startGame)
        {
            if (canSpawn)
            {
                waveInfoText.text = "Spawning Enemies...";

                if (spawnTimerOn && amountOfEnemysForWave[currentWaveNum] > 0)
                {
                    spawnTimer -= Time.deltaTime;

                    if (spawnTimer <= 0)
                    {
                        spawnTimer = spawnTimerDefault[currentWaveNum];
                        Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity, enemyParent);
                        amountOfEnemysForWave[currentWaveNum]--;
                        currentAmountOfEnemiesSpawned++;
                    }
                }
            }
        }

        if (currentAmountOfEnemiesSpawned == totalEnemiesCurrentWave)
        {
            canSpawn = false;
            waveInfoText.text = "Wave in progress...";
        }

        if (currentWaveNum == amountOfWaves - 1)
        {
            SceneManager.LoadScene("Win scene");
        }

        if (currentAmountOfEnemiesSpawned == totalEnemiesCurrentWave && amountOfEnemiesKilled == totalEnemiesCurrentWave)
        {
            if (doOnce)
            {
                nutsPerWave += 10;
                timeBetweenWavesTimer = timeBetweenWaves;
                bird.CanBribeOn();
                bird.ReceiveBribe();
                doOnce = false;
            }
            timeBetweenWavesTimer -= Time.deltaTime;
            canSpawn = false;
            waveInfoText.text = "Waiting for next wave : " + Mathf.Round(timeBetweenWavesTimer);
            if (timeBetweenWavesTimer <= 0)
            {
                doOnce = true;
                canSpawn = true;
                currentWaveNum++;
                totalEnemiesCurrentWave = amountOfEnemysForWave[currentWaveNum];
                currentAmountOfEnemiesSpawned = 0;
                amountOfEnemiesKilled = 0;
            }

            if (currentWaveNum >= amountOfWaves)
            {
                print("Game won!");
            }
        }
    }

    public void IncreaseEnemiesKilled()
    {
        amountOfEnemiesKilled++;
    }

    public int ReceiveNuts()
    {
        return nutsPerWave;
    }

    public void DeleteDeezNuts()
    {
        nutsPerWave = 0;
    }

    public void StartGame()
    {
        startGame = true;
    }

    public bool GetStartGame()
    {
        return startGame;
    }
}