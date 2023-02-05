using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildInteract : MonoBehaviour
{
    [SerializeField] Image interactable;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject outsideCam;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject eToReturn;
    [SerializeField] GameObject squirel;
    [SerializeField] Nuts nuts;
    [SerializeField] EnemySpawn enemySpawn;

    private bool isOutside;

    private bool canUse;

    public void Start()
    {
        interactable.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactable.enabled = true;
            canUse = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable.enabled && isOutside == false && canUse)
        {
            if (nuts.GetAmountOfNuts() > 0)
            {
                enemySpawn.StartGame();
            }
            canUse = false;
            isOutside = true;
            cam2.SetActive(false);
            outsideCam.SetActive(true);
            eToReturn.SetActive(true);
            squirel.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.enabled = false;
    }

    public bool IsOutside()
    {
        return isOutside;
    }

    public void SetIsOutside(bool IIsOutside)
    {
        isOutside = IIsOutside;
    }
}