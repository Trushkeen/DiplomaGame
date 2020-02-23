using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: assign switching to controls
public class WeaponSwitcher : MonoBehaviour
{
    //TODO: when loading a player into the scene, assign here a weapons from his inventory
    public GameObject PrimaryWeapon;
    public GameObject SecondaryWeapon;
    public GameObject MeleeWeapon;

    //TODO: animations
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            DisableAllWeapons();
            PrimaryWeapon.SetActive(true);
            PrimaryWeapon.GetComponent<Animator>().Play("Idle");

        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            DisableAllWeapons();
            SecondaryWeapon.SetActive(true);
            SecondaryWeapon.GetComponent<Animator>().Play("Idle");

        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            DisableAllWeapons();
            MeleeWeapon.SetActive(true);
            MeleeWeapon.GetComponent<Animator>().Play("Idle");

        }
    }

    private void DisableAllWeapons()
    {
        PrimaryWeapon.SetActive(false);
        SecondaryWeapon.SetActive(false);
        MeleeWeapon.SetActive(false);
    }
}
