using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Menu_UI : MonoBehaviour {

    public Text descText;
    public Text nameText;

    public Item_List_Script inventory;
    public Equipment_Script gearList;

    Inventory_Slot[] slots;
    Equip_Slot[] equipSlots;

    private void Start()
    {
        slots = GetComponentsInChildren<Inventory_Slot>();
        equipSlots = GetComponentsInChildren<Equip_Slot>();
        inventory.OnItemUpdate += UIChanger;
        gearList.OnGearUpdate += GearUIChanger;
        UIChanger();
        foreach (Equip_Class equip in gearList.gearList)
        {
            GearUIChanger(equip);
        }
    }

    private void OnDestroy()
    {
        inventory.OnItemUpdate -= UIChanger;
    }

    void GearUIChanger(Equip_Class equipment)
    {
        foreach (Equip_Slot equipslot in equipSlots)
        {
            if (equipslot.itemCategory == equipment.equipSlot)
            {
                equipslot.AddItem(equipment);
            }
        }
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
