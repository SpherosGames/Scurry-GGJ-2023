using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TTS : MonoBehaviour
{
    public TMP_Text Dialogue;
    public string[] lines;
    public float textSpeed;
    private int index;
    void Start()
    {
        Dialogue.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButton(0))
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
        foreach(char c in lines[index].ToCharArray())
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
            gameObject.SetActive(false);
        }
    }
}
