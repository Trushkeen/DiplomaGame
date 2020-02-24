using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public string Name;
    /// <summary>
    /// If you want to damage an enemy, use <b>DealDamage</b> method instead
    /// </summary>
    public float HP;
    public float Damage;
    public float Speed;

    public void DealDamage(float val)
    {
        print(HP);
        HP -= val;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
