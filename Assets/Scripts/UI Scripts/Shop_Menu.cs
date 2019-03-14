using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Menu : MonoBehaviour
{
    public string shopName;
    public Item_List_Script shopList;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                UI_Manager.Current.EnableUIPanel_Shop(UI_Manager.Current.shopPanel, shopName, shopList);
            }
        }
    }
}
