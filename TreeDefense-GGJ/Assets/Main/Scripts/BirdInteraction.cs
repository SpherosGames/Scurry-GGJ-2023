using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdInteraction : MonoBehaviour
{
    [SerializeField] private Nuts nuts;
    [SerializeField] private EnemySpawn waves;

    [SerializeField] Image interactable;
    [SerializeField] private GameObject birdInteractionScreen;

    private int nutsToReceive;

    public void Start()
    {
        interactable.enabled = false;
        birdInteractionScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactable.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && interactable.enabled == true)
        {
            birdInteractionScreen.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        birdInteractionScreen.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void Receive()
    {
        nuts.RemoveNuts(-nutsToReceive);
    }

    public void Bribe()
    {

    }
}