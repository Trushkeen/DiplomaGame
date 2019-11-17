using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRifle : MonoBehaviour
{
    public float Damage { get; set; } = 23;
    public float Accuracy { get; set; } = 50;
    public float AmmoTotal { get; set; } = 1000;
    public float AmmoClip { get; set; } = 30;
    public float AmmoNow { get; set; } = 30;

    public GameObject BulletPoint;

    private bool AbleToShoot = true;
    private AudioSource SoundEmitter;
    private Animator AnimController;

    private void Start()
    {
        SoundEmitter = GetComponent<AudioSource>();
        AnimController = GetComponent<Animator>();
    }

    public void Reload()
    {
        AnimController.SetBool("Reloading", false);
        if (AmmoTotal >= AmmoClip)
        {
            AmmoTotal += AmmoNow;
            AmmoNow = AmmoClip;
            AmmoTotal -= AmmoClip;
        }
        else if (AmmoTotal - (AmmoClip - AmmoNow) < 0)
        {
            AmmoNow += AmmoTotal;
            AmmoTotal = 0;
        }
        else if (AmmoTotal < AmmoClip)
        {
            var diff = AmmoClip - AmmoNow;
            AmmoNow += diff;
            AmmoTotal -= diff;
        }
    }

    public void Shoot()
    {
        if (AbleToShoot && AmmoNow > 0)
        {
            SoundEmitter.Play();
            if (Physics.Raycast(BulletPoint.transform.position, BulletPoint.transform.forward, out RaycastHit hit, 100F, ~(2 << 8), QueryTriggerInteraction.Ignore))
            {
                var go = hit.collider.gameObject;
                if (go.CompareTag("Enemy"))
                {
                    go.GetComponent<Mob>().HP -= Damage;
                }
            }
            MouseMove.ShakeCamera();
            AmmoNow--;
            StartCoroutine(ShootingCooldown());
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && AnimController.GetBool("Reloading") == false)
        {
            Shoot();
            //PrintAmmo();
        }
        if (Input.GetKeyDown(KeyCode.R) && AnimController.GetBool("Reloading") == false && AmmoNow != AmmoClip)
        {
            Reload();
            AnimController.SetBool("Reloading", true);
            //Reload();
            //PrintAmmo();
        }
    }

    private IEnumerator ShootingCooldown()
    {
        AbleToShoot = false;
        yield return new WaitForSeconds(0.1F);
        AbleToShoot = true;
    }

    private void PrintAmmo()
    {
        print(AmmoNow + "/" + AmmoTotal);
    }
}
