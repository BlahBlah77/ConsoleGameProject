using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DefaultName", menuName = "Equipment/Equipable Item")]
public class Equip_Class : Item_Class {

    public Equip_Slot_Enum equipSlot;

    public override void UseItem()
    {
        base.UseItem();
        Inventory_Manager.InventMana.EquipItem(this);
    }
}
