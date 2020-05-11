using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreenControl : MonoBehaviour
{
    public TextMeshProUGUI LoginText;
    public TextMeshProUGUI PasswordText;
    public GameObject ErrorLogData;

    public void ProceedAuth()
    {
        try
        {
            if (!Auth.IsLoggingNow)
            {
            Auth.IsLoggingNow = true;
            Auth.ConfirmUserData(LoginText.text, PasswordText.text);
            }
            else
            {
            print("Client already connecting, wait...");
            }
        }
        catch (ArgumentException) 
        {
            ErrorLogData.SetActive(true);
        }
    }
    public void CreateAccount()
    {
        System.Diagnostics.Process.Start("https://mplace.azurewebsites.net/Home/Register");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
