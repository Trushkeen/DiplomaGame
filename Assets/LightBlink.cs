using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightBlink : MonoBehaviour
{
    public float Chance = 0.2F;
    private Light Light;

    void Start()
    {
        Light = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        if (Random.value <= Chance)
        {
            Light.enabled = true;
        }
        else 
        {
            Light.enabled = false;
        }

    }
}
