using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour, IDamager
{
    public GameObject zombieTest;
    public Animator anim;
    public Item_Class weapon;
    public Base_Enemy_Control baseEnemy;
    public Int_Stat_Script weaponStrength;
    public float damage;

    public Equip_Slot_Enum equipSlot;
    public Equipment_Script gear;

    public string itemName;
    public string description;

    public GameObject swordModel;
    MeshFilter meshFil;
    SkinnedMeshRenderer skinMeshil;
    Renderer andworck;


    private void Start()
    {
        meshFil = swordModel.GetComponent<MeshFilter>();
        skinMeshil = swordModel.GetComponent<SkinnedMeshRenderer>();
        andworck = swordModel.GetComponent<Renderer>();
        ItemEquip(gear.gearList[(int)equipSlot]);
        gear.OnGearUpdate += ItemEquip;
        weaponStrength.OnIntUpdate += StrengthInput;

        // testing for hit reaction animation on zombie when sword is hitting the enemy
        anim = zombieTest.GetComponent<Animator>();
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
        if (meshFil) meshFil.mesh = weapon.itemModel.GetComponent<MeshFilter>().sharedMesh;
        if (skinMeshil) skinMeshil.sharedMesh = weapon.itemModel.GetComponent<MeshFilter>().sharedMesh;
        if (andworck) andworck.material = weapon.itemModel.GetComponent<Renderer>().sharedMaterial;
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

    public float DoDamage()
    {
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if i hit anything that implemets the iDamageable
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            float newDamage = DoDamage();
            Debug.Log("You are hit");

            // testing for hit reaction animation on zombie when sword is hitting the enemy
            anim.SetTrigger("isTakingDamage");

            damageable.TakeDamage(newDamage); // the thing that is hit with the interface will take damage to its health
        }
    }
}
