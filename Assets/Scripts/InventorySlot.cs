using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Loot Item;
    public Image Icon;
    public Text Name;

    public Text SellBtnText;
    public GameObject SellBtnParent;
    public GameObject DeleteButton;

    private void Start()
    {
        SellBtnText.text = "$" + Item.Cost;
    }

    public void AddItem(Loot item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        Name.text = item.Name;
    }

    public void ClearSlot()
    {
        Inventory.Instance.Items.Remove(gameObject);
        Destroy(gameObject);
    }

    public void SellItem()
    {
        var stats = GameObject.FindObjectOfType<PlayerStats>();
        stats.Balance += Item.Cost;
        ClearSlot();
    }
}
