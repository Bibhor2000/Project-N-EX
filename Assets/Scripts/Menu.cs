using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadTelemetry()
    {
        SceneManager.LoadSceneAsync("BaseSecondScene");
    }

    public void LoadConfig()
    {
        SceneManager.LoadSceneAsync("BaseThirdScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("BaseScene");
    }
}
