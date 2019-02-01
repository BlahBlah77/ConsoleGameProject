using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Collectible : MonoBehaviour {

    public Int_Stat_Script playerXP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerXP.IntPlusChanger(100);
            gameObject.SetActive(false);
        }
    }
}
