using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    private bool AbleToShoot = true;

    public float Damage { get; set; } = 60;
    public float Accuracy { get; set; } = 20;
    public float AmmoTotal { get; set; } = 3;
    public float AmmoClip { get; set; } = 2;
    public float AmmoNow { get; set; } = 2;

    public GameObject BulletPoint;

    private AudioSource SoundEmitter;

    private Animator AnimController;

    public void Reload()
    {
        AnimController.SetBool("Reload", false);
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
       
        if (AbleToShoot && AmmoNow!=0) {
            SoundEmitter.Play();

            for (int Bull = 0; Bull < 8; Bull++) {

                Debug.DrawRay(BulletPoint.transform.position, BulletPoint.transform.forward * 100f, Color.red);

                if (Physics.Raycast(BulletPoint.transform.position, BulletPoint.transform.forward * Random.Range(0.1F, 0.9F), out RaycastHit hit, 100F, ~(2 << 8), QueryTriggerInteraction.Ignore))
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
            StartCoroutine(ShootingCooldown());
        }
    }

    void Start()
    {
        SoundEmitter = GetComponent<AudioSource>();
        AnimController = GetComponent<Animator>();
    }

    void Update()
    {
        print(AmmoNow);

        if (Input.GetMouseButton(0)&&AnimController.GetBool("Reload") == false)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R)&& AnimController.GetBool("Reload") == false && AmmoNow != AmmoClip && AmmoTotal!=0)
        {
            //Reload();
            AnimController.SetBool("Reload", true);
        }
    }
    IEnumerator ShootingCooldown()
    {
        AbleToShoot = false;
        yield return new WaitForSeconds(0.9F);
        AbleToShoot = true;
    }
}
