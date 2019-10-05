using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float Damage { get; set; }
    float Accuracy { get; set; }
    float ReloadTime { get; set; }
    float AmmoTotal { get; set; }
    float AmmoClip { get; set; }
    float AmmoNow { get; set; }

    void Shoot();

    void Reload();
}
