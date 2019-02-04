using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour {

    public Item_Class weapon;
    public Int_Stat_Script weaponStrength;
    public float damage;

    public string itemName;
    public string description;

    MeshFilter meshFil;
    Renderer andworck;

    private void Start()
    {
        meshFil = GetComponent<MeshFilter>();
        andworck = GetComponent<Renderer>();
        ItemEquip(weaponStrength.initialisedVariable);
        weaponStrength.OnIntUpdate += ItemEquip;
    }

    private void OnDestroy()
    {
        weaponStrength.OnIntUpdate -= ItemEquip;
    }

    public void ItemEquip(int newValue)
    {
        damage = DamageCalculator(newValue);
        itemName = weapon.name;
        description = weapon.itemDescription;
        meshFil.mesh = weapon.itemModel.GetComponent<MeshFilter>().sharedMesh;
        andworck.material = weapon.itemModel.GetComponent<Renderer>().sharedMaterial;
    }

    float DamageCalculator(int damageVal)
    {
        float imper = weapon.stat * damageVal;
        return imper;
    }
}
