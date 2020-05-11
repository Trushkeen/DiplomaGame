using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Player;
    public GameObject crosshair;
    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

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
        crosshair.active = true;
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        MouseMove.Unfreeze();
        Cursor.visible = false;
        GameManager.EnableDisabledWeapons();
        
    }

    void Pause()
    {
        crosshair.active = false;
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
}
