using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightBlink : MonoBehaviour
{
    Light Light;
    void Start()
    {
        Light = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        var ran = Random.value;
        if (ran <= .2)
        {
            Light.enabled = true;
        }
        else 
        {
            Light.enabled = false;
        }

    }
}
