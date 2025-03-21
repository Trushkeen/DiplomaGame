﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    public WeaponBase WB;

    Animator AnimController;
    public void Attack(GameObject obj)
    {
        if (obj.gameObject != null)
        {
            obj.GetComponent<Mob>().HP -= 8;
            Destroy(obj);
            obj.GetComponent<Rigidbody>().AddForce(transform.up * 300F + transform.forward * 300F, ForceMode.Acceleration);

        }
    }
    public void IsColliderStart()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void IsColliderEnd()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(Controls.FireBtn))
        {
            AnimController.SetBool("Attack", true);
        }
        if (Input.GetKeyUp(Controls.FireBtn))
        {
            AnimController.SetBool("Attack", false);
        }
           
    }
    void Start()
    {
        AnimController = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Attack(other.gameObject);
            }
        }
    }
}
