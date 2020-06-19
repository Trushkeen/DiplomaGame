using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Player;
    public GameObject Crosshair;
    public Slider slider;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        AudioListener.volume = slider.value;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                Cursor.visible = false;
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Crosshair.SetActive(true);
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        MouseMove.Unfreeze();
        Cursor.visible = false;
        GameManager.EnableDisabledWeapons();
        
    }

    void Pause()
    {
        Crosshair.SetActive(false);
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        MouseMove.Freeze();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.DisableActiveWeapons();
    }

    public void LoadMenu()
    {
        MouseMove.Unfreeze();
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowTab(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HideTab(GameObject obj)
    {
        obj.SetActive(false);
    }
}
