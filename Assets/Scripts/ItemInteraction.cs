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
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100F, ~(12 << 8), QueryTriggerInteraction.Ignore))
        {
            InteractionGO.SetActive(true);
            if (!Locale.LocaleLoaded) Locale.LoadLocale();
            InteractionText.text = Locale.Get("presstopickup") + hit.collider.gameObject.name;
        }
        else
        {
            InteractionGO.SetActive(false);
        }
    }
}
