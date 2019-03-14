using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Menu_UI : MonoBehaviour {

    public Text descText;
    public Text nameText;

    public Item_List_Script inventory;

    Inventory_Slot[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<Inventory_Slot>();
        inventory.OnItemUpdate += UIChanger;
        UIChanger();
    }

    private void OnDestroy()
    {
        inventory.OnItemUpdate -= UIChanger;
    }

    void UIChanger()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }

    public void AddText(Item_Class newItem)
    {
        if (newItem != null)
        {
            descText.text = newItem.itemDescription;
            nameText.text = newItem.itemName;
        }
    }

    public void RemoveText()
    {
        descText.text = "";
        nameText.text = "";
    }

}
