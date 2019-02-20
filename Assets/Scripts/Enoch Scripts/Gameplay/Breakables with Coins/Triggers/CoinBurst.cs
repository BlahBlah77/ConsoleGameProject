using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBurst : MonoBehaviour {

    ObjectPooler objectPooler;

    // Use this for initialization
    void Awake ()
    {
        GetComponent<PickupEvent>().OnCollection += CoinBurst_OnCollection;
        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    void SetupSpawnedCoins(GameObject newCoin)
    {
        newCoin.transform.position = gameObject.transform.position;
        newCoin.GetComponent<Rigidbody>().useGravity = true;
        newCoin.GetComponent<Collider>().isTrigger = false;
        newCoin.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 50);

        // sets the collider of the coins back on trigger after 0.5 seconds.
        CoinTriggerActivator newCoinLogicScript = newCoin.GetComponent<CoinTriggerActivator>();
        newCoinLogicScript.Invoke("ActivateCoin", 0.5f);
    }

    private void CoinBurst_OnCollection(object sender, System.EventArgs e)
    {
        Burst();
    }

    void Burst()
    {        
        int numberOfCoins = UnityEngine.Random.Range(1, 6);

        for (int x = 0; x < numberOfCoins; x++)
        {
           GameObject newCoin = objectPooler.GetCoin();
           SetupSpawnedCoins(newCoin);
        } 
    }
}
