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
        InvokeRepeating("RestoreHP", 1F, 1F);
    }

    public void DiscardHP(float value)
    {
        HP -= value;
        if (HP <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private void RestoreHP()
    {
        if (HP < 100)
        {
            if (HP > 70)
                AddHP(1);
            else if (HP > 50)
                AddHP(2);
            else
                AddHP(3);
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
