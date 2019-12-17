using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreenControl : MonoBehaviour
{
    public TextMeshProUGUI LoginText;
    public TextMeshProUGUI PasswordText;

    void Start()
    {
        
    }

    public void LoadToMainMenu()
    {
        OnlineUser.Login(LoginText.text, PasswordText.text);
        if (OnlineUser.LoggedIn)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
