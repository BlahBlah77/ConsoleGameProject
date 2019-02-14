using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultName", menuName = "Equipment/Gear List")]
public class Equipment_Script : ScriptableObject {

    public Equip_Class[] gearList;

    public delegate void OnGearUpdateHandle(Equip_Class newVal);
    public event OnGearUpdateHandle OnGearUpdate;

    //private void Start()
    //{
    //    int slotNum = System.Enum.GetNames(typeof(Equip_Slot_Enum)).Length;
    //    gearList = new Equip_Class[slotNum];
    //}

    public void GearAdd(Equip_Class item)
    {
        int index = (int)item.equipSlot;
        gearList[index] = item;
        if (OnGearUpdate != null)
        {
            OnGearUpdate(item);
        }
    }

    public void GearRemove(Equip_Class item)
    {
        int index = (int)item.equipSlot;
        gearList[index] = null;
        if (OnGearUpdate != null)
        {
            OnGearUpdate(item);
        }
    }

    public void GearItemRemove()
    {
        int slotNum = System.Enum.GetNames(typeof(Equip_Slot_Enum)).Length;
        gearList = new Equip_Class[slotNum];
    }
}
