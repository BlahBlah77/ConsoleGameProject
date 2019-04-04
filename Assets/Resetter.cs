using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {

    [Header("Stored Player Stats")]
    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;
    public Int_Stat_Script playerMoney;
    public Int_Stat_Script playerHealth;
    public Int_Stat_Script playerStrength;
    public Int_Stat_Script playerDefence;
    public Item_List_Script playerInvent;
    public Equipment_Script playerGear;
    public List<Item_List_Script> listShops;

    private void Start()
    {
        playerHealth.runVariable = playerHealth.initialisedVariable;
        playerLevel.runVariable = playerLevel.initialisedVariable;
        playerMoney.runVariable = playerMoney.initialisedVariable;
        playerXP.runVariable = playerXP.initialisedVariable;
        playerXP.runVariable2 = playerXP.initialisedVariable2;
        playerDefence.runVariable = playerDefence.initialisedVariable;
        playerStrength.runVariable = playerStrength.initialisedVariable;
        playerGear.gearList = playerGear.defaultGearList;
        playerInvent.FullItemRemove();
        foreach (Item_List_Script shop in listShops)
        {
            shop.itemList = shop.defaultItemList;
        }
    }
}
