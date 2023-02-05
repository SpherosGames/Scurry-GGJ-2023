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

    [SerializeField] private TMP_Text bribeText;
    [SerializeField] private GameObject bribeButton;

    private int nutsToReceive;
    private int nutsToSend;

    private bool canBribe = true;

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
        if (canBribe)
        {
            bribeButton.SetActive(true);
        }
        else
        {
            bribeButton.SetActive(false);
        }
    }

    public void Receive()
    {
        nutsToReceive += waves.ReceiveNuts();
        nuts.RemoveNuts(-nutsToReceive);
        nutsToReceive = 0;
        waves.DeleteDeezNuts();
    }

    public void AddNuts()
    {
        nutsToSend += 100;
        bribeText.text = "Confirm : " + nutsToSend;
    }

    public void RemoveNuts()
    {
        nutsToSend -= 100;
        bribeText.text = "Confirm : " + nutsToSend;
    }

    public void ConfirmBribe()
    {
        nuts.RemoveNuts(nutsToSend);
        canBribe = false;
    }

    public void CanBribeOn()
    {
        canBribe = true;
    }

    public void ReceiveBribe()
    {
        nutsToReceive += nutsToSend * 2;
        print(nutsToReceive);
    }
}