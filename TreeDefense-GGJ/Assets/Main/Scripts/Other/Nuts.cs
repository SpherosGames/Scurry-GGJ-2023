using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Nuts : MonoBehaviour
{
    [SerializeField] private int nutCount;
    [SerializeField] private TMP_Text nutCountText;
    [SerializeField] private EnemySpawn enemySpawn;

    private void Update()
    {
        nutCountText.text = " : " + nutCount.ToString();

        if (enemySpawn.GetStartGame())
        {
            if (nutCount <= 0)
            {
                print("The Tree DIED!");
                Time.timeScale = 0;
            }
        }
    }

    public void AddNuts(int amount)
    {
        nutCount += amount;
    }

    public void RemoveNuts(int amount)
    {
        nutCount -= amount;
    }

    public int GetAmountOfNuts()
    {
        return nutCount;
    }
}