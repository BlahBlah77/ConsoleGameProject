using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBurst : MonoBehaviour {

    ObjectPooler objectPooler;

    // Use this for initialization
    void Awake ()
    {
        GetComponent<PickupEvent>().OnCollection += HealthBurst_OnCollection;
        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    void SetupSpawnedHealth(GameObject newHealth)
    {
        newHealth.transform.position = gameObject.transform.position;
        newHealth.GetComponent<Rigidbody>().useGravity = true;
        newHealth.GetComponent<Collider>().isTrigger = false;
        newHealth.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 50);

        // sets the collider of the coins back on trigger after 0.5 seconds.
        CoinTriggerActivator newHealthLogicScript = newHealth.GetComponent<CoinTriggerActivator>();
        newHealthLogicScript.Invoke("ActivateCoin", 0.5f);
    }

    private void HealthBurst_OnCollection(object sender, System.EventArgs e)
    {
        Burst();
    }

    void Burst()
    {        
        int numberOfHealthPacks = UnityEngine.Random.Range(1, 6);

        for (int x = 0; x < numberOfHealthPacks; x++)
        {
            GameObject newHealth = objectPooler.GetHealthPack();
            SetupSpawnedHealth(newHealth);
        } 
    }
}
