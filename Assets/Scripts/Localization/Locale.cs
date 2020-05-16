using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Locale
{
    public static string Language { get; private set; } = "en";
    public static bool LocaleLoaded = false;
    private static Dictionary<string, string> CurrentLocale;

    public static void LoadLocale()
    {
        CurrentLocale = new Dictionary<string, string>();
        var loc = Resources.Load<TextAsset>("Translations\\" + Language).text.Split('-');
        foreach (var i in loc)
        {
            var str = i.Split('=');
            if (str[0].Length > 2)
                CurrentLocale.Add(str[0].Replace("=", ""), str[1].Replace("-", ""));
        }
        LocaleLoaded = true;
    }

    public static void ChangeLanguage(string lng)
    {
        if (lng.Length > 2 || lng.Length < 2)
        {
            throw new System.Exception("Wrong format");
        }
        else
        {
            Language = lng;
        }
    }

    public static string Get(string key)
    {
        return CurrentLocale[key.ToLower()];
    }
}
