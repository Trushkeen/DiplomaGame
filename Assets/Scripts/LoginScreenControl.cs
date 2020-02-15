using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreenControl : MonoBehaviour
{
    public TextMeshProUGUI LoginText;
    public TextMeshProUGUI PasswordText;

    public void ProceedAuth()
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
}
