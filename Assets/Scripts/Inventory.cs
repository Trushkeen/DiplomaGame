using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(Controls.AccessInventory))
        {
            if (!InventoryUI.activeSelf)
            {
                InventoryUI.SetActive(true);
            }
            else
            {
                InventoryUI.SetActive(false);
            }
        }
    }
}
