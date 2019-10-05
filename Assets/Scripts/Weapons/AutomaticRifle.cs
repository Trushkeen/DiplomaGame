using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRifle : MonoBehaviour, IWeapon
{
    public float Damage { get; set; } = 23;
    public float Accuracy { get; set; } = 50;
    public float ReloadTime { get; set; } = 1.7F;
    public float AmmoTotal { get; set; } = 250;
    public float AmmoClip { get; set; } = 30;
    public float AmmoNow { get; set; } = 30;

    public void Reload()
    {
        if (AmmoNow != AmmoClip)
        {
            if (AmmoTotal > AmmoClip)
            {
                AmmoTotal += AmmoNow;
                AmmoNow = AmmoClip;
                AmmoTotal -= AmmoClip;
            }
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100F, ~(2 << 8), QueryTriggerInteraction.Ignore))
        {
            var go = hit.collider.gameObject;
            if (go.CompareTag("Enemy"))
            {
                go.GetComponent<Mob>().HP -= Damage;
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
}
