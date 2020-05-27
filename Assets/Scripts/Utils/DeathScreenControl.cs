using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenControl : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
