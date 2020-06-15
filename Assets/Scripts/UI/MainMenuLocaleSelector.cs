using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLocaleSelector : MonoBehaviour
{
    public GameObject SelectLocaleGroup;

    public void RevertGroupVisibility()
    {
        if (SelectLocaleGroup.activeSelf)
        {
            SelectLocaleGroup.SetActive(false);
        }
        else
        {
            SelectLocaleGroup.SetActive(true);
        }
    }

    public void SelectLocale(string locale)
    {
        Locale.ChangeLanguage(locale);
        Locale.LoadLocale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
