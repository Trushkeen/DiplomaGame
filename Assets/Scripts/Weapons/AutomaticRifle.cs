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

    private bool AbleToShoot = true;
    private AudioSource SoundEmitter;

    private void Start()
    {
        SoundEmitter = GetComponent<AudioSource>();
    }

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
        if (AbleToShoot && AmmoNow > 0)
        {
            SoundEmitter.Play();
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100F, ~(2 << 8), QueryTriggerInteraction.Ignore))
            {
                var go = hit.collider.gameObject;
                if (go.CompareTag("Enemy"))
                {
                    go.GetComponent<Mob>().HP -= Damage;
                }
            }
            AmmoNow--;
            print(AmmoNow);
            StartCoroutine(ShootingCooldown());
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    IEnumerator ShootingCooldown()
    {
        AbleToShoot = false;
        yield return new WaitForSeconds(0.05F);
        AbleToShoot = true;
    }
}
