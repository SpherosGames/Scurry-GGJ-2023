using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public Canvas pauseMenu;
    bool isPaused;
    private void Start()
    {
        isPaused = false;
        pauseMenu.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Debug.Log("Werkt 1");
            pauseMenu.enabled = true;
            isPaused = true;
            Time.timeScale = 0f;
        }
            
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Debug.Log("Werkt 2");
            Time.timeScale = 1f;
            pauseMenu.enabled = false;
            isPaused = false;
        }
    }

public void ResumeButton()
    {
        Time.timeScale = 1f;
        pauseMenu.enabled = false;
    }
public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
        
    }
}
