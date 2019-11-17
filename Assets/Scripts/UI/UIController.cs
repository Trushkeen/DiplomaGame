using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI DebugText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI AmmoText;
    
    private Camera PlayerCamera;

    void Start()
    {
        PlayerCamera = Camera.main;
    }

    void Update()
    {
        UpdateHPText();
        UpdateAmmoText();
    }

    void UpdateHPText()
    {
        var playerStats = PlayerCamera.transform.root.gameObject.GetComponent<PlayerStats>();
        HPText.text = "HP: " + playerStats.HP;
    }

    void UpdateAmmoText()
    {
        var currentWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<WeaponBase>();
        if (currentWeapon.AmmoClip != 0)
        {
            AmmoText.text = $"{currentWeapon.AmmoNow}/{currentWeapon.AmmoTotal}";
        }
        else
        {
            AmmoText.text = "MELEE";
        }
    }
}
