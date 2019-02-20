using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Scoring : MonoBehaviour {

    public EventManager eventmanager;
    public Text coinText;
    int currentCoinScore = 0;
    int maxCoinScore = 9999;

	// Use this for initialization
	void Start ()
    {
        eventmanager.OnAnyCoinCollected += Eventmanager_OnAnyCoinCollected;
	}

    private void Eventmanager_OnAnyCoinCollected(object sender, EventArgs e)
    {      
        if (currentCoinScore < maxCoinScore)
        {
            currentCoinScore++;
            coinText.text = "Coins: " + currentCoinScore;
        }
        else
        {
            currentCoinScore = maxCoinScore;
            coinText.text = "Coins: " + currentCoinScore;
            Debug.Log("You have collected the max coins");
        }
    }

    private void Update()
    {
        
    }
}
