using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDelete : MonoBehaviour
{
    public int Chance = 80;

    void Start()
    {
        if (Random.Range(0, 100) < Chance)
        {
            Destroy(gameObject);
        }
    }
}
