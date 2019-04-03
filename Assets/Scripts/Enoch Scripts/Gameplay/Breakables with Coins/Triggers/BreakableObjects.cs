using System.Collections;
using System;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour {

    public GameObject CoinTest;
    private int numberOfCoins;
    private int numberOfHealthPacks;

    public event EventHandler<CoinArgs> OnSmashBox; // declare event
    public event EventHandler<HealthArgs> OnSmashBoxHealth; // for special items
    
    // make method to call an event
    void RaiseSmashBox(CoinArgs args, HealthArgs hargs)
    {
        if(OnSmashBox != null)
            OnSmashBox.Invoke(this, args);
    }

    private void OnTriggerEnter(Collider other)
    {
        numberOfCoins = UnityEngine.Random.Range(5, 6);
        numberOfHealthPacks = UnityEngine.Random.Range(5, 6);

        if (other.gameObject.tag == "sword")
        {
           RaiseSmashBox(new CoinArgs(numberOfCoins), new HealthArgs(numberOfHealthPacks));
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

public class HealthArgs: EventArgs
{
    public int healthSpawns { get; private set; }
    public HealthArgs(int numOfHealthPacks)
    {
        healthSpawns = numOfHealthPacks;
    }
}
