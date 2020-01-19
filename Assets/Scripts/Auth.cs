using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Auth : MonoBehaviour
{
    public static bool Authorized = false;
    public static OnlineUser ThisUser;

    private static string Email;
    private static string Password;
    private const string Code = "db249957-a31d-428e-b9ca-3fcd4a60770c";
    private static UnityWebRequest req;

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
        req = UnityWebRequest.Get(@"https://mplace.azurewebsites.net/api/v1/login?email=" + Email
            + "&password=" + Password + "&code=" + Code);
        var response = req.SendWebRequest();
        response.completed += OnRequestCompleted;
    }

    private static void OnRequestCompleted(AsyncOperation obj)
    {
        if (req.responseCode == 200)
        {
            Authorized = true;
            ThisUser = new OnlineUser();
            ThisUser.ParseJsonUserString(req.downloadHandler.text);
            SceneManager.LoadScene("MainMenu");
        }
        else if (req.responseCode == 400)
        {
            print("User not found");
        }
        else if(req.responseCode >= 500)
        {
            print("Server is down");
        }
    }

    public static void LoadLoginScreen()
    {
        SceneManager.LoadScene("LoginScreen");
    }
}
