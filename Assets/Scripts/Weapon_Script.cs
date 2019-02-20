using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour {

    public Item_Class weapon;
    public Int_Stat_Script weaponStrength;
    public float damage;

    public Equip_Slot_Enum equipSlot;
    public Equipment_Script gear;

    public string itemName;
    public string description;

    MeshFilter meshFil;
    Renderer andworck;

    private void Start()
    {
        meshFil = GetComponent<MeshFilter>();
        andworck = GetComponent<Renderer>();
        //ItemEquip(Inventory_Manager.InventMana.currGear[(int)equipSlot]);
        ItemEquip(gear.gearList[(int)equipSlot]);
        gear.OnGearUpdate += ItemEquip;
        weaponStrength.OnIntUpdate += StrengthInput;
        //Inventory_Manager.InventMana.OnGearChanged += 
    }

    private void OnDestroy()
    {
        weaponStrength.OnIntUpdate -= StrengthInput;
        gear.OnGearUpdate -= ItemEquip;
    }

    public void ItemEquip(Equip_Class newWeapon)
    {
        if (newWeapon.equipSlot != equipSlot)
        {
            return;
        }
        weapon = newWeapon;
        damage = DamageCalculator(weaponStrength.runVariable);
        itemName = weapon.name;
        description = weapon.itemDescription;
        meshFil.mesh = weapon.itemModel.GetComponent<MeshFilter>().sharedMesh;
        andworck.material = weapon.itemModel.GetComponent<Renderer>().sharedMaterial;
    }

    public void StrengthInput(int newValue)
    {
        damage = DamageCalculator(newValue);
    }

    float DamageCalculator(int damageVal)
    {
        float imper;
        if (weapon != null)
        {
            imper = weapon.stat * damageVal;
        }
        else
        {
            imper = 0;
        }
        return imper;
    }
}
