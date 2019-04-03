using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Giver : MonoBehaviour
{
    public string levelID;
    public string levelName;
    public string dialogue;
    public int moneyReq;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                string newDialogue = dialogue + levelName + "?";
                UI_Manager.Current.EnableUIPanel_Quest(UI_Manager.Current.questPanel, newDialogue, levelID, moneyReq);
            }
        }
    }
}
