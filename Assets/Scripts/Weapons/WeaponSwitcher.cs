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

    private GameObject CurrentWeapon;
    private GameObject PreviousWeapon;

    private void Start()
    {
        CurrentWeapon = PrimaryWeapon;
        DisableAllWeapons();
        CurrentWeapon.SetActive(true);
    }

    //TODO: animations
    void Update()
    {
        if (Input.GetKeyUp(Controls.PreviousWeapon) && PreviousWeapon != null)
        {
            CurrentWeapon.SetActive(false);
            PreviousWeapon.SetActive(true);
            GameObject temp = PreviousWeapon;
            PreviousWeapon = CurrentWeapon;
            CurrentWeapon = temp;
        }

        if (Input.GetKey(Controls.PrimaryWeaponBtn) && CurrentWeapon != PrimaryWeapon)
        {
            SwitchWeapons(PrimaryWeapon);
        }
        else if (Input.GetKey(Controls.SecondaryWeaponBtn) && CurrentWeapon != SecondaryWeapon)
        {
            SwitchWeapons(SecondaryWeapon);
        }
        else if (Input.GetKey(Controls.MeleeWeaponBtn) && CurrentWeapon != MeleeWeapon)
        {
            SwitchWeapons(MeleeWeapon);
        }
    }

    private void SwitchWeapons(GameObject sender)
    {
        PreviousWeapon = CurrentWeapon;
        CurrentWeapon.SetActive(false);
        sender.SetActive(true);
        sender.GetComponent<Animator>().Play("Idle");
        CurrentWeapon = sender;
    }

    private void DisableAllWeapons()
    {
        CurrentWeapon.SetActive(false);
        PrimaryWeapon.SetActive(false);
        SecondaryWeapon.SetActive(false);
        MeleeWeapon.SetActive(false);
    }
}
