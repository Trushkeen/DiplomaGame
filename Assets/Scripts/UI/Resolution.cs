using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    public TMP_Dropdown Dropdown;
    public void ChangeResolution()
    {
        switch (Dropdown.value)
        {
            case 0:
                Screen.SetResolution(800, 600, true);
                break;
            case 1:
                Screen.SetResolution(1024, 768, true);
                break;
            case 2:
                Screen.SetResolution(1280, 1024, true);
                break;
            case 3:
                Screen.SetResolution(1600, 1200, true);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}
