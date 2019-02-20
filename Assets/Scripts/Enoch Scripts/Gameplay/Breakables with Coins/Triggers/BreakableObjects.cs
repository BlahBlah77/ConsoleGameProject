using System.Collections;
using System;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour {

    public GameObject CoinTest;
    private int numberOfCoins;

    public event EventHandler<CoinArgs> OnSmashBox; // declare event
    public event EventHandler<SpecialArgs> OnSmashSpecialBox; // for special items
    
    // make method to call an event
    void RaiseSmashBox(CoinArgs args)
    {
        if(OnSmashBox != null)
            OnSmashBox.Invoke(this, args);
    }

    private void Start()
    {
        SetupSpawnedCoins();
    }

    void SetupSpawnedCoins()
    {
        //CoinTest.GetComponent<Rigidbody>().useGravity = true;
        //CoinTest.GetComponent<Collider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        numberOfCoins = UnityEngine.Random.Range(5, 6);

        if (other.gameObject.tag == "sword")
        {
           RaiseSmashBox(new CoinArgs(numberOfCoins));
        }
    }
}

// custom event argument that passes info about the number of coins spawned..
public class CoinArgs: EventArgs
{
    public int coinsSpawns { get; private set; }
    public CoinArgs(int numOfCoins)
    {
        coinsSpawns = numOfCoins;
    }
}

public class SpecialArgs: EventArgs
{

}
