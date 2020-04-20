using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //TODO: death screen if 0
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
