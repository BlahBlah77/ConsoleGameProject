using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI_Control : MonoBehaviour {

    //Player_Reference_Holder playerRefs;
    Game_Manager gmRef;

    void Start ()
    {
        //playerRefs = GetComponent<Player_Reference_Holder>();
        gmRef = Game_Manager.Instance;
    }

    void Update ()
    {
		if(Input.GetButtonDown("Pause"))
        {
            if (!gmRef.isPaused)
            {
                Event_Manager_Luke.TriggerEvent("PauseToggle");
                gmRef.isPaused = true;
            }
            else
            {
                Event_Manager_Luke.TriggerEvent("PauseToggle");
                gmRef.isPaused = false;
            }
        }
	}
}
