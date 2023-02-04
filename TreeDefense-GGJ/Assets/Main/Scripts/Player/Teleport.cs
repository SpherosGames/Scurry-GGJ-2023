using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{
    public Image interactable;
    public GameObject Squirrel;
    public Transform targetTP;
    public GameObject VCam1;
    public GameObject VCam2;

    bool VCamActieve;

    // Start is called before the first frame update
    void Start()
    {
        interactable.enabled = false;
        VCam2.SetActive(false);
        VCamActieve = true;

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
            Squirrel.transform.localPosition = targetTP.transform.localPosition;
            if (VCamActieve == true)
            {
                VCam1.SetActive(false);
                VCam2.SetActive(true);
                VCamActieve = false;
            }
            //else
            //{
            //    VCam1.SetActive(true);
            //    VCam2.SetActive(false);
            //    VCamActieve = true;
            //}
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.enabled = false;
  
    }
}