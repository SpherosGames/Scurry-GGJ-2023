using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Main Level", LoadSceneMode.Single);
    }
    public void Options()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }



}



