using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHpChanged(); 

    public int ID;
    public string Nickname = string.Empty;

    public float HP { get; private set; } = 100;
    public float Speed = 5;

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
}
