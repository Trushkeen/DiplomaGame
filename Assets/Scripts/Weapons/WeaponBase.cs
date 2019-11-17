using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float Damage { get; set; }
    public float Accuracy { get; set; }
    public float AmmoTotal { get; set; }
    public float AmmoClip { get; set; }
    public float AmmoNow { get; set; }
}
