using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartEvents : MonoBehaviour
{
    private bool DevelopMode = false;

    private void Start()
    {
        if (!Locale.LocaleLoaded)
        {
            Locale.LoadLocale();
        }

        if (Auth.Authorized && !DevelopMode)
        {
            //do something
        }
        else if (!DevelopMode)
        {
            Auth.LoadLoginScreen();
        }
    }
}
