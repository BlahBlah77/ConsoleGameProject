using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve_Ball : MonoBehaviour {

    public Int_Stat_Script playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.IntMinusChanger(5);
            Destroy(gameObject);
        }
    }

}
