using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public TextMeshProUGUI BalanceText;
    public int Space = 12;
    public List<GameObject> Items = new List<GameObject>();
    public GameObject BasicCell;

    #region Singleton
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            print("Several instances of inventory found");
            return;
        }
        Instance = this;
    }
    #endregion

    public void Update()
    {
        if (Input.GetKeyUp(Controls.AccessInventory))
        {
            if (!InventoryUI.activeSelf)
            {
                EnableInv();
            }
            else
            {
                DisableInv();
            }
        }
    }

    public void EnableInv()
    {
        InventoryUI.SetActive(true);
        GameManager.DisableActiveWeapons();
        MouseMove.Freeze();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableInv()
    {
        foreach (var cell in Items)
        {
            cell.GetComponent<InventorySlot>().SellBtnParent.SetActive(false);
        }

        InventoryUI.SetActive(false);
        GameManager.EnableDisabledWeapons();
        MouseMove.Unfreeze();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
