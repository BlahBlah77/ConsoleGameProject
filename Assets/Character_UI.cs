using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_UI : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
       {
            UI_Manager.Current.EnableClick();
       }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_Manager.Current.DisableClick();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
