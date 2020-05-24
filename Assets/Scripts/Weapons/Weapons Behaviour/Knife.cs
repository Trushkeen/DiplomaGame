using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Animator Animator;
    private bool ReadyToAttack = true;
    private WeaponBase WB;

    void Start()
    {
        Animator = GetComponent<Animator>();
        WB = GetComponent<WeaponBase>();
    }

    private void OnEnable()
    {
        Animator.Play("Idle");
        ReadyToAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Mob>().DealDamage(WB.Damage);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && ReadyToAttack)
        {
            Animator.Play("Attack1");
            ReadyToAttack = false;
        }
    }

    public void SetAttackReadyToTrue()
    {
        ReadyToAttack = true;
    }
}
