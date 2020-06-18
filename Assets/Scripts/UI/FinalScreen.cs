using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    //https://mplace.azurewebsites.net/api/v1/balance?id=10001&amount=-2&code=

    public TextMeshProUGUI EarnedText;
    public Image LoadingImage;
    public GameObject ExitButton;

    private float EarnedMoney = DataContainer.MoneyEarned;
    private float LerpValue = 0;
    private const string Code = "db249957-a31d-428e-b9ca-3fcd4a60770c";
    private UnityWebRequest Request;

    private void Start()
    {
        //test user's id for debug
        int id = 10001;
        if (Auth.ThisUser != null)
        {
            id = Auth.ThisUser.Id;
        }
        
        Request = UnityWebRequest.Get(@"https://mplace.azurewebsites.net/api/v1/balance?id=" + id
            + "&amount=" + EarnedMoney + "&code=" + Code);
        var response = Request.SendWebRequest();
        response.completed += OnRequestFinished;
    }

    private void Update()
    {
        EarnedText.text = Mathf.Lerp(0, EarnedMoney, LerpValue).ToString("0");
        LerpValue += 0.005F;
    }

    private void OnRequestFinished(AsyncOperation obj)
    {
        LoadingImage.enabled = false;
        ExitButton.SetActive(true);
        switch (Request.responseCode)
        {
            case 200: print("OK");
                break;
            default: print("Something went wrong");
                break;
        }
    }
}
