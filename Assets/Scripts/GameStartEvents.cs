using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartEvents : MonoBehaviour
{
    private void Start()
    {
        if (!Locale.LocaleLoaded)
        {
            Locale.LoadLocale();
        }
        if (OnlineUser.LoggedIn)
        {
            //do something
        }
        else
        {
            OnlineUser.LoadLoginScreen();
        }
    }
}
