using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Manager : MonoBehaviour {

    public float playerHealth = 100f;
    public int playerLevel = 1;
    public int playerStrength = 1;
    public float playerExperience = 0;

    public delegate void OnPlayerExperienceUpdateHandle(float currentExperience, float newExperience);
    public event OnPlayerExperienceUpdateHandle OnPlayerExperienceUpdate;

    public void ExperienceUpdate(float xp)
    {
        if (xp !=0)
        {
            if (OnPlayerExperienceUpdate != null)
            {
                OnPlayerExperienceUpdate(playerExperience, xp);
            }
            playerExperience += xp;
        }
    }
}
