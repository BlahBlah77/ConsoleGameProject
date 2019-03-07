﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Slot : MonoBehaviour {

    [SerializeField]
    Item_Class storedItem;
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

    public void Interact()
    {
        if (storedItem)
        {
            Inventory_Manager.InventMana.AddItem(storedItem);

        }
    }
}
