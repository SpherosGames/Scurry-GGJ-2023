using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("Lose scene");
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