using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Scoring : MonoBehaviour {

    public EventManager eventmanager;
    public Text coinText;
    int currentCoinScore = 0;

	// Use this for initialization
	void Start ()
    {
        eventmanager.OnAnyCoinCollected += Eventmanager_OnAnyCoinCollected;
	}

    private void Eventmanager_OnAnyCoinCollected(object sender, EventArgs e)
    {      

        if (currentCoinScore < 100)
        {
            currentCoinScore++;
            coinText.text = "Coins: " + currentCoinScore;
        }
        else
        {
            currentCoinScore = 100;
            coinText.text = "Coins: " + currentCoinScore;
        }
    }


}
