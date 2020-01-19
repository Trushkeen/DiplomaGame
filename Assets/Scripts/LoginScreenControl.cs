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

    void Start()
    {
        
    }

    public void ProceedAuth()
    {
        try
        {
            Auth.ConfirmUserData(LoginText.text, PasswordText.text);
        }
        catch (ArgumentException) 
        {
            ErrorLogData.SetActive(true);
        }
    }
}
