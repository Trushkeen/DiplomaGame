using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Loot Item;
    public Image Icon;
    public Text Name;

    public void AddItem(Loot item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        Name.text = item.Name;
    }

    public void ClearSlot()
    {
        Destroy(this.gameObject);
    }
}
