using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public WeaponBase WB;

    public GameObject BulletPoint;

    private bool AbleToShoot = true;
    private WeaponSoundController Emitter;
    private Animator AnimController;

    private void Start()
    {
        WB = GetComponent<WeaponBase>();
        Emitter = GetComponent<WeaponSoundController>();
        AnimController = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        AnimController?.Play("Out", 0);
        StartCoroutine(ShootingCooldown());
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
        if (AbleToShoot && WB.AmmoNow > 0)
        {
            Emitter.PlayShot();
            if (Physics.Raycast(BulletPoint.transform.position, -BulletPoint.transform.forward, out RaycastHit hit, 200F, ~(2 << 8), QueryTriggerInteraction.Ignore))
            {
                Debug.DrawRay(BulletPoint.transform.position, BulletPoint.transform.forward * -100F, Color.red, 10f);

                var go = hit.collider.gameObject;
                while (go.transform.parent != null)
                {
                    go = go.transform.parent.gameObject;
                }
                if (go.CompareTag("Enemy"))
                {
                    go.GetComponent<Mob>().DealDamage(WB.Damage);
                }
            }
            MouseMove.ShakeCamera();
            WB.AmmoNow--;
            StartCoroutine(ShootingCooldown());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(Controls.FireBtn) && AnimController.GetBool("Reloading") == false)
        {
            Shoot();
        }
        if (Input.GetKeyDown(Controls.ReloadBtn) && AnimController.GetBool("Reloading") == false && WB.AmmoNow != WB.AmmoClip)
        {
            //Reload();
            AnimController.SetBool("Reloading", true);
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
        print(WB.AmmoNow + "/" + WB.AmmoTotal);
    }
}
