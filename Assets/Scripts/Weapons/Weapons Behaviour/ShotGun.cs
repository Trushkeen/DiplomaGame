using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    private bool AbleToShoot = true;

    public WeaponBase WB;

    public GameObject BulletPoint;

    private WeaponSoundController Emitter;

    private Animator AnimController;

    void Start()
    {
        WB = GetComponent<WeaponBase>();
        Emitter = GetComponent<WeaponSoundController>();
        AnimController = GetComponent<Animator>();
    }

    public void Reload()
    {
        AnimController.SetBool("Reloading", false);
        if (WB.AmmoTotal >= WB.AmmoClip)
        {
            WB.AmmoTotal += WB.AmmoNow;
            WB.AmmoNow = WB.AmmoClip;
            WB.AmmoTotal -= WB.AmmoClip;
        }
        else if (WB.AmmoTotal - (WB.AmmoClip - WB.AmmoNow) < 0)
        {
            WB.AmmoNow += WB.AmmoTotal;
            WB.AmmoTotal = 0;
        }
        else if (WB.AmmoTotal < WB.AmmoClip)
        {
            var diff = WB.AmmoClip - WB.AmmoNow;
            WB.AmmoNow += diff;
            WB.AmmoTotal -= diff;
        }
    }

    public void Shoot()
    {
        if (AbleToShoot && WB.AmmoNow != 0)
        {
            Emitter.PlayShot();

            for (int bullet = 0; bullet < 8; bullet++)
            {
                //TODO: shotgun doesn't have a dispersion
                Debug.DrawRay(BulletPoint.transform.position, BulletPoint.transform.forward * 100f, Color.red, 1F);

                if (Physics.Raycast(BulletPoint.transform.position, BulletPoint.transform.forward * Random.Range(0.1F, 0.9F), out RaycastHit hit, 100F, ~(2 << 8), QueryTriggerInteraction.Ignore))
                {
                    var go = hit.collider.gameObject;
                    if (go.CompareTag("Enemy"))
                    {
                        go.GetComponent<Mob>().HP -= WB.Damage;
                    }
                    bullet++;
                }
            }
            WB.AmmoNow--;
            MouseMove.ShakeCamera();
            StartCoroutine(ShootingCooldown());
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && AnimController.GetBool("Reloading") == false)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && AnimController.GetBool("Reloading") == false && WB.AmmoNow != WB.AmmoClip && WB.AmmoTotal != 0)
        {
            //Reload();
            AnimController.SetBool("Reloading", true);
        }
    }
    IEnumerator ShootingCooldown()
    {
        AbleToShoot = false;
        yield return new WaitForSeconds(0.3F);
        AbleToShoot = true;
    }
}
