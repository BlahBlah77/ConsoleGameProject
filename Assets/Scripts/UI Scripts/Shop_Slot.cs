using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Slot : MonoBehaviour {

    [SerializeField]
    Item_Class storedItem;
    public Int_Stat_Script playerMoney;
    public Shop_Menu_UI uiRef;
    public Image iconImage;

    public void AddItem(Item_Class newItem)
    {
        storedItem = newItem;
        if (storedItem == null) Debug.Log("Kill me");
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
        if (storedItem && (playerMoney.initialisedVariable >= storedItem.itemValue))
        {
            int newMoney = playerMoney.initialisedVariable - storedItem.itemValue;
            playerMoney.IntMinusChanger(newMoney);
            Inventory_Manager.InventMana.AddItem(storedItem);
            uiRef.shopList.ItemRemove(storedItem);
            RemoveItem();
        }
    }

}
