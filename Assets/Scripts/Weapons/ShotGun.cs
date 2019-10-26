using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour,IWeapon
{
    private bool AbleToShoot = true;

    public float Damage { get; set; } = 60;
    public float Accuracy { get; set; } = 20;
    public float ReloadTime { get; set; } = 1F;
    public float AmmoTotal { get; set; } = 25;
    public float AmmoClip { get; set; } = 2;
    public float AmmoNow { get; set; } = 2;

    public GameObject BulletPoint;

    private AudioSource SoundEmitter;

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
        if (AbleToShoot) {
            SoundEmitter.Play();

            for (int Bull = 0; Bull < 8; Bull++) {

                if (Physics.Raycast(BulletPoint.transform.position, transform.forward * Random.Range(10, 100), out RaycastHit hit, 100F, ~(2 << 8), QueryTriggerInteraction.Ignore))
                {
                    var go = hit.collider.gameObject;
                    if (go.CompareTag("Enemy"))
                    {
                        go.GetComponent<Mob>().HP -= Damage;
                    }
                    Bull++;
                }
            }
            AmmoNow--;
            print(AmmoNow);
            StartCoroutine(ShootingCooldown());
        }
    }

    void Start()
    {
        SoundEmitter = GetComponent<AudioSource>();
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
        yield return new WaitForSeconds(0.9F);
        AbleToShoot = true;
    }
}
