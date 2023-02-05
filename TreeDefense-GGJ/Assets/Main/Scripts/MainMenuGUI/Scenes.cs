using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Canvas OptionsMenu;
    public Canvas MainMenu;

    public void Start()
    {
        OptionsMenu.enabled = false;
        MainMenu.enabled = true;
    }
    public void Play()
    {
        SceneManager.LoadScene("TreeHouse", LoadSceneMode.Single);
    }
    public void Options()
    {
        OptionsMenu.enabled = true;
        MainMenu.enabled = false;
    }

    public void ReturnMM()
    {
        MainMenu.enabled = true;
        OptionsMenu.enabled = false;
    }    

}



