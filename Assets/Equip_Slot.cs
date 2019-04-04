using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip_Slot : MonoBehaviour {

    public Item_Class storedItem;
    public Equip_Slot_Enum itemCategory;
    public Inventory_Menu_UI uiRef;
    public Image iconImage;

    public void AddItem(Item_Class newItem)
    {
        storedItem = newItem;
        iconImage.sprite = newItem.itemIcon;
    }

    public void RemoveItem()
    {
        storedItem = null;
        iconImage.sprite = null;
    }
    public void AddText()
    {
        uiRef.AddText(storedItem);
    }
}
