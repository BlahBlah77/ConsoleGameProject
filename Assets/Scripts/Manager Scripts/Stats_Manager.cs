using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Manager : MonoBehaviour {

    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;
    public Int_Stat_Script playerStrength;
    public Int_Stat_Script playerDefence;
    public Equipment_Script gearList;

    private void Start()
    {
        playerXP.OnIntUpdate += ExperienceChecker;
        gearList.OnGearUpdate += DefenceCalculator;
        foreach (Equip_Class equip in gearList.gearList)
        {
            DefenceCalculator(equip);
        }
    }

    private void OnDestroy()
    {
        playerXP.OnIntUpdate -= ExperienceChecker;
        gearList.OnGearUpdate -= DefenceCalculator;
    }

    void ExperienceChecker(int value)
    {
        if (value >= playerXP.runVariable2)
        {
            int newXP = value - playerXP.runVariable2;
            playerXP.IntSetValChanger(newXP);

            playerLevel.IntPlusChanger(1);
            playerStrength.IntPlusChanger(1);

            int newVal = playerXP.runVariable2 + (playerXP.runVariable2 / 3);
            playerXP.SecondIntSetValChanger(newVal);


        }
    }

    public void DefenceCalculator(Equip_Class currEquip)
    {
        if (((int)currEquip.equipSlot != 3) && ((int)currEquip.equipSlot != 4))
        {
            playerDefence.runVariable = (int)gearList.gearList[0].stat + (int)gearList.gearList[1].stat + (int)gearList.gearList[2].stat;
            Debug.Log(playerDefence.runVariable);
        }
    }

    //public void ExperienceUpdate(float xp)
    //{
    //    if (xp !=0)
    //    {
    //        if (OnPlayerExperienceUpdate != null)
    //        {
    //            OnPlayerExperienceUpdate(playerExperience, xp);
    //        }
    //        playerExperience += xp;
    //    }
    //}
}
