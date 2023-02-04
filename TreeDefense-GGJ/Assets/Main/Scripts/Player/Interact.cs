using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] Image interactable; // Dit is de "E" van de squirrel
    [SerializeField] TMP_Text signDialog; // dialog van een sign 
    [SerializeField] Image backGroundDialog;
    [SerializeField] string dialogueText;

    public void Start()
    {
        interactable.enabled = false;
        signDialog.enabled = false;
        backGroundDialog.enabled = false;

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
            signDialog.text = dialogueText;
            signDialog.enabled = true;
            backGroundDialog.enabled = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.enabled = false;
        signDialog.enabled = false;
        backGroundDialog.enabled = false;
    }
}