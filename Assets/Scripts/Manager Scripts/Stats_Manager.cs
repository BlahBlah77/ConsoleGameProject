using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Manager : MonoBehaviour {

    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;
    public Int_Stat_Script playerStrength;

    private void Start()
    {
        playerXP.OnIntUpdate += ExperienceChecker;
    }

    private void OnDestroy()
    {
        playerXP.OnIntUpdate -= ExperienceChecker;
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
