﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Terrain>().detailObjectDensity = 50000;
    }
}
