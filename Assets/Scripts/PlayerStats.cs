using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int ID;
    public string Nickname = string.Empty;

    [SerializeField]
    private float HP = 100;

    public float Speed = 5;

    public float Balance = 0;

    private void Start()
    {
        ID = PlayersManager.GetInstance().GetAvailableID();
    }

    public void DiscardHP(float value)
    {
        HP -= value;
        if (HP <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void AddHP(float value)
    {
        HP += value;
    }

    public float GetHP()
    {
        return HP;
    }
}
