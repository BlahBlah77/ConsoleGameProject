using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Manager : MonoBehaviour {

    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;
    public int playerStrength = 1;

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
            playerLevel.IntPlusChanger(1);
            playerXP.IntSetValChanger(0);
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
