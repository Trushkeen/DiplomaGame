using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemInteraction : MonoBehaviour
{
    public GameObject InventoryUI;

    public GameObject InteractionGO;

    private TextMeshProUGUI InteractionText;
    private AudioSource LootSound;

    private void Start()
    {
        InteractionText = InteractionGO.GetComponent<TextMeshProUGUI>();
        LootSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 25F, ~(12 << 8), QueryTriggerInteraction.Collide))
        {
            var go = hit.collider.gameObject;

            if (!Locale.LocaleLoaded) Locale.LoadLocale();

            if (go.tag == "Loot")
            {
                InteractionGO.SetActive(true);
                InteractionText.text = Locale.Get("presstopickup") + go.GetComponent<LootableItem>().Loot.Name;
                if (Input.GetKeyUp(KeyCode.E))
                {
                    PickupLoot(go);
                }
            }
            else if (go.tag == "QuestLoot")
            {
                InteractionGO.SetActive(true);
                InteractionText.text = Locale.Get("presstopickup") + go.GetComponent<LootableItem>().Loot.Name;
                if (Input.GetKeyUp(KeyCode.E))
                {
                    PickupLoot(go, questItem: true);
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
                            var slot = cell.GetComponent<InventorySlot>();
                            if (slot.DeleteButton.activeSelf)
                            {
                                slot.SellBtnParent.SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        inv.DisableInv();
                    }
                }
            }
            else if (go.tag == "EscapeTrigger")
            {
                InteractionGO.SetActive(true);
                InteractionText.text = "[E] - " + Locale.Get("escape");

                if (Input.GetKeyUp(KeyCode.E))
                {
                    DataContainer.MoneyEarned = FindObjectOfType<PlayerStats>().Balance;
                    SceneManager.LoadScene("FinalScreen");
                }
            }
        }
        else
        {
            InteractionGO.SetActive(false);
        }
    }

    private void PickupLoot(GameObject obj, bool questItem = false)
    {
        var lootItem = obj.GetComponent<LootableItem>();
        var loot = lootItem.Loot;
        if (Inventory.Instance.Items.Count < Inventory.Instance.Space)
        {
            LootSound.Play();
            var cell = Instantiate(Inventory.Instance.BasicCell, InventoryUI.transform);
            var slot = cell.GetComponent<InventorySlot>();
            if (questItem)
            {
                slot.DeleteButton.SetActive(false);
                if (lootItem.HasVOClip)
                {
                    lootItem.PlayVOClip();
                    QuestManager.Instance.UpdateObjective();
                }
            }
            slot.AddItem(loot);
            Inventory.Instance.Items.Add(cell);
            Destroy(obj);
        }
    }
}
