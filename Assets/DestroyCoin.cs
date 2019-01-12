using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour/*IScorer*/ {

    int coins;
    int currentCoins;


   //public float getCoinsAdded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

   // public void CoinsAdded(float amount)
    //{
    //    throw new System.NotImplementedException();
    //}

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            // ADD A SCORE OF 1... (WILL BE ADDED VIA INTERFACES)
        }
    }
}
