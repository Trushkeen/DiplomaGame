using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainElements;
    public GameObject SettingsElements;

    public void StartDebugLevel()
    {
        SceneManager.LoadScene("DebugScene", LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        //MainElements.SetActive(false);
        //SettingsElements.SetActive(true);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
