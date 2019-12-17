using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class OnlineUser
{
    private static string Token;

    //change value of this field to false to skip auth
    public static bool LoggedIn { get; private set; } = false;

    public static void LoadLoginScreen()
    {
        SceneManager.LoadScene("LoginScreen");
    }

    public static void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //TODO: make auth with connection to the server
    public static void Login(string token)
    {
        LoggedIn = true;
        ReturnToMenu();
    }

    public static void Login(string login, string password)
    {
        LoggedIn = true;
        ReturnToMenu();
    }
}