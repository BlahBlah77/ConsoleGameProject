using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour {

    public Item_Class weapon;
    public float damage;

    public string itemName;
    public string description;

    MeshFilter meshFil;
    Renderer andworck;

    private void Start()
    {
        meshFil = GetComponent<MeshFilter>();
        andworck = GetComponent<Renderer>();
        ItemEquip();
    }

    public void ItemEquip()
    {
        damage = weapon.stat;
        itemName = weapon.name;
        description = weapon.itemDescription;
        meshFil.mesh = weapon.itemModel.GetComponent<MeshFilter>().sharedMesh;
        andworck.material = weapon.itemModel.GetComponent<Renderer>().sharedMaterial;
    }
}
