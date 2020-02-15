using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Auth : MonoBehaviour
{
    public static bool IsLoggingNow = false;
    public static bool Authorized = false;
    public static OnlineUser ThisUser;

    private static string Email;
    private static string Password;
    private const string Code = "db249957-a31d-428e-b9ca-3fcd4a60770c";
    private static UnityWebRequest AuthRequest;

    public static void ConfirmUserData(string email, string password)
    {
        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && email.Contains("@"))
        {
            Email = email.Replace("\u200B", "");
            Password = password.Replace("\u200B", "");
            AuthUser();
        }
        else
        {
            throw new ArgumentException("Invalid data");
        }
    }

    private static void AuthUser()
    {
        AuthRequest = UnityWebRequest.Get(@"https://mplace.azurewebsites.net/api/v1/login?email=" + Email
            + "&password=" + Password + "&code=" + Code);
        var response = AuthRequest.SendWebRequest();
        response.completed += OnRequestCompleted;
    }

    private static void OnRequestCompleted(AsyncOperation obj)
    {
        switch (AuthRequest.responseCode)
        {
            case 200:
                Authorized = true;
                ThisUser = new OnlineUser();
                ThisUser.ParseJsonUserString(AuthRequest.downloadHandler.text);
                IsLoggingNow = false;
                SceneManager.LoadScene("MainMenu");
                break;
            case 400: print("User not found");
                break;
            case 502: print("Bad gateway"); 
                break;
            default: print(AuthRequest.responseCode + ": troubles with connection");
                break;
        }
        IsLoggingNow = false;
    }

    public static void LoadLoginScreen()
    {
        SceneManager.LoadScene("LoginScreen");
    }
}
