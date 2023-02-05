using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TTS : MonoBehaviour
{
    public TMP_Text Dialogue;
    public string[] lines;
    public float textSpeed;
    private bool isInteractable;
    private int index;
    [SerializeField] Image interactable; // Dit is de "E" van de squirrel
    [SerializeField] TMP_Text signDialog; // dialog van een sign 
    [SerializeField] Image backGroundDialog;
  //  [SerializeField] string dialogueText;
    void Start()
    {
        interactable.enabled = false;
        signDialog.enabled = false;
        backGroundDialog.enabled = false;
        Dialogue.text = string.Empty;
        StartDialogue();
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

        isInteractable = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.enabled = false;
        signDialog.enabled = false;
        backGroundDialog.enabled = false;
    }
        // Update is called once per frame
        void Update()
        {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable && interactable.enabled)
            {

            signDialog.enabled = true;
            backGroundDialog.enabled = true;
            StartDialogue();

             }
             if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Dialogue.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    Dialogue.text = lines[index];
                }
            }
        }
        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }
        IEnumerator TypeLine()
        {
            foreach (char c in lines[index].ToCharArray())
            {
                Dialogue.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

        }
        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                Dialogue.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
              //  gameObject.SetActive(false);
            }
        }
    }

