﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public Slider slider;

    void Update() 
    {
        AudioListener.volume = slider.value;
    }

    public void StartDebugLevel()
    {
        SceneManager.LoadScene("City_Level1", LoadSceneMode.Single);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void Site()
    {
        System.Diagnostics.Process.Start("https://mplace.azurewebsites.net/");
    }

    public void ShowTab(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HideTab(GameObject obj)
    {
        obj.SetActive(false);
    }
}
