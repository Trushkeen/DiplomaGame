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

    public void ProceedAuth()
    {
        Auth.ConfirmUserData(LoginText.text, PasswordText.text);
    }
}
