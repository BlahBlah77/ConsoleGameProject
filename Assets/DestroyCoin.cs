using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour, IPoolableObject/*IScorer*/ {

    ObjectPooler objectpool;
    int coins;
    int currentCoins;

    void Start()
    {
        GetComponent<PickupEvent>().OnCollection += DestroyCoin_OnCollection;
    }

    private void DestroyCoin_OnCollection(object sender, System.EventArgs e)
    {
        objectpool.CoinReturn(this.gameObject);
    }



    //public float getCoinsAdded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // public void CoinsAdded(float amount)
    //{
    //    throw new System.NotImplementedException();
    //}
    
    public void SetObjectPool(ObjectPooler objectPooler)
    {
        objectpool = objectPooler;
    }
}
