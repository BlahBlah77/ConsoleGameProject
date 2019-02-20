using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Switcher : MonoBehaviour
{

    public List<Weapon_Script> listOfWeapons;

    public int equipedWeapon;
    public bool isSwitching = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = equipedWeapon;
        isSwitching = false;
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0)
        {
            if (equipedWeapon >= listOfWeapons.Count - 1)
            {
                equipedWeapon = 0;
            }
            else
            {
                equipedWeapon++;
            }
            isSwitching = true;
        }
        else if (scrollWheel < 0.0f)
        {
            if (equipedWeapon <= 0)
            {
                equipedWeapon = listOfWeapons.Count - 1;
            }
            else
            {
                equipedWeapon--;
            }
            isSwitching = true;
        }

        if (previousWeapon != equipedWeapon)
        {
            SwitchAndCheckWeapons();
        }
    }

    void SwitchAndCheckWeapons()
    {
        int weapNumber = 0;
        foreach (Weapon_Script weap in listOfWeapons)
        {
            if (weapNumber == equipedWeapon)
            {
                weap.gameObject.SetActive(true);
            }
            else
            {
                weap.gameObject.SetActive(false);
            }
            ++weapNumber;
        }
    }
}
