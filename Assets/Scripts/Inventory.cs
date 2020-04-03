using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public int Space = 12;
    public List<GameObject> Cells;

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

    void Update()
    {
        if (Input.GetKeyUp(Controls.AccessInventory))
        {
            if (!InventoryUI.activeSelf)
            {
                InventoryUI.SetActive(true);
                GameManager.DisableActiveWeapons();
                MouseMove.Freeze();
            }
            else
            {
                InventoryUI.SetActive(false);
                GameManager.EnableDisabledWeapons();
                MouseMove.Unfreeze();
            }
        }
    }
}
