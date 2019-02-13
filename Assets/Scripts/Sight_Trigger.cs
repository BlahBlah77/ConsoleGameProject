using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight_Trigger : MonoBehaviour {

    public bool playerSpotted;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerSpotted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerSpotted = false;
        }
    }
}