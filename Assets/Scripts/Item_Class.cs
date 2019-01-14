using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultName", menuName = "Equipment/Item")]
public class Item_Class : ScriptableObject
{
    public GameObject itemModel;
    public string itemName = "Item Name";
    public Sprite itemIcon = null;
    public string itemDescription = "This is an item without a description, give me one you fuck";
    public float stat = 0.0f;
    public bool isWeapon = false;
    public bool isEquipable = false;
}
