using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScorer
{
    // function to add coins 
    void CoinsAdded(float amount);

    // getter and setter for actual value of coins
    float getCoinsAdded { get; set; }
}
