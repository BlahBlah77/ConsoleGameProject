using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour {

    Item_Class storedItem;
    public Inventory_Menu_UI uiRef;
    public Image iconImage;

    public void AddItem(Item_Class newItem)
    {
        storedItem = newItem;
    }

    public void RemoveItem()
    {
        storedItem = null;
    }
    public void AddText()
    {
        uiRef.AddText(storedItem);
    }
}
