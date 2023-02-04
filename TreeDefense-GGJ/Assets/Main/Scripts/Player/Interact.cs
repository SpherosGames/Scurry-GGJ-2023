using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Interact : MonoBehaviour
{
    public TMP_Text interactable; // Dit is de "E" van de squirrel
    public TMP_Text signDialog; // dialog van een sign 

    public void Start()
    {
        interactable.enabled = false;
        signDialog.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Werkt");
            interactable.enabled = true;
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.E) && interactable.enabled == true)
            {
                signDialog.enabled = true;
        
            }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.enabled = false;
        signDialog.enabled = false;
    }

}
