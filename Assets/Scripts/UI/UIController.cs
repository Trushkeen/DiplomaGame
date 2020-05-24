using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI DebugText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI BalanceText;

    public Image HPBar;

    private Camera PlayerCamera;
    private PlayerStats Stats;

    void Start()
    {
        PlayerCamera = Camera.main;
        Stats = PlayerCamera.transform.root.gameObject.GetComponent<PlayerStats>();
        BalanceText = Inventory.Instance.BalanceText;
    }

    void Update()
    {
        if (GameManager.DisabledWeapons == null)
        {
            UpdateAmmoText();
        }
        UpdateHPInfo();
        UpdateBalanceText();
    }

    void UpdateHPInfo()
    {
        HPText.text = Stats.GetHP().ToString();
        HPBar.fillAmount = Stats.GetHP() / 100F;
    }

    void UpdateAmmoText()
    {
        var currentWeapon = GameObject.FindObjectOfType<WeaponBase>();
        if (currentWeapon.AmmoClip != 0)
        {
            AmmoText.text = $"{currentWeapon.AmmoNow}/{currentWeapon.AmmoTotal}";
        }
        else
        {
            AmmoText.text = "MELEE";
        }
    }

    void UpdateBalanceText()
    {
        Inventory.Instance.BalanceText.text = Stats.Balance.ToString();
    }
}
