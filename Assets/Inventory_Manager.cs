using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour {

    public static Inventory_Manager InventMana;

    public Item_List_Script inventory;
    public Equipment_Script currentGear;
    //public Equip_Class[] currGear;

    //public delegate void OnGearChangedHandle (Equip_Class newGear);
    //public event OnGearChangedHandle OnGearChanged;

    private void Awake()
    {
        InventMana = this;
    }

    //private void Start()
    //{
    //    int slotNum = System.Enum.GetNames(typeof(Equip_Slot_Enum)).Length;
    //    currGear = new Equip_Class[slotNum];
    //}

    public void EquipItem(Equip_Class newGear)
    {
        currentGear.GearAdd(newGear);
        //int index = (int)newGear.equipSlot;
        //currGear[index] = newGear;
        //if (OnGearChanged != null)
        //{
        //    OnGearChanged(newGear);
        //}
    }

    public void AddItem(Item_Class item)
    {
        inventory.ItemAdd(item);
    }

    public void RemoveItem(Item_Class item)
    {
        inventory.ItemRemove(item);
    }
}
