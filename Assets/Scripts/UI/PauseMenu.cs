using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Player;
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
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        MouseMove.Unfreeze();
        Player.GetComponentInChildren<AutomaticRifle>().enabled = true;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        MouseMove.Freeze();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Player.GetComponentInChildren<AutomaticRifle>().enabled = false;
    }

    public void LoadMenu()
    {
        MouseMove.Unfreeze();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
