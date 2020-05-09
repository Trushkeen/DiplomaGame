using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject InventoryUI;

    public GameObject InteractionGO;
    private TextMeshProUGUI InteractionText;

    private void Start()
    {
        InteractionText = InteractionGO.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10F, ~(12 << 8), QueryTriggerInteraction.Collide))
        {
            var go = hit.collider.gameObject;

            if (!Locale.LocaleLoaded) Locale.LoadLocale();

            if (go.tag == "Loot")
            {
                InteractionGO.SetActive(true);

                InteractionText.text = Locale.Get("presstopickup") + hit.collider.gameObject.name;
                if (Input.GetKeyUp(KeyCode.E))
                {
                    var loot = go.GetComponent<LootableItem>().Loot;
                    if (Inventory.Instance.Items.Count < Inventory.Instance.Space)
                    {
                        var cell = Instantiate(Inventory.Instance.BasicCell, InventoryUI.transform);
                        var slot = cell.GetComponent<InventorySlot>();
                        slot.AddItem(loot);
                        Inventory.Instance.Items.Add(cell);
                        Destroy(go);
                    }
                }
            }
            else if (go.tag == "VendingMachine")
            {
                InteractionGO.SetActive(true);

                InteractionText.text = "[E] - " + Locale.Get("interact");

                if (Input.GetKeyUp(KeyCode.E))
                {
                    var inv = Inventory.Instance;
                    if (!inv.InventoryUI.activeSelf)
                    {
                        inv.EnableInv();

                        foreach (var cell in inv.Items)
                        {
                            cell.GetComponent<InventorySlot>().SellBtnParent.SetActive(true);
                        }
                    }
                    else
                    {
                        inv.DisableInv();
                    }
                }
            }
            else if(go.tag == "EscapeTrigger")
            {
                InteractionGO.SetActive(true);

                InteractionText.text = "[E] - " + Locale.Get("escape");

                if (Input.GetKeyUp(KeyCode.E))
                {
                    
                }
            }
        }
        else
        {
            InteractionGO.SetActive(false);
        }
    }
}
