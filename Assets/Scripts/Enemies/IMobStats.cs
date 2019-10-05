using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMobStats
{
    string Name { get; set; }
    float HP { get; set; }
    float Damage { get; set; }
    float Speed { get; set; }
}
