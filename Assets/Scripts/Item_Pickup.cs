using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour, IPickupable {

    public Item_Class item;

    public void Interact()
    {
        Inventory_Manager.InventMana.AddItem(item);
        gameObject.SetActive(false);
    }
}
