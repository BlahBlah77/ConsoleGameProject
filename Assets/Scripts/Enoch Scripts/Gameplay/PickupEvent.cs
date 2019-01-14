using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEvent : MonoBehaviour, IPoolableObject {

    public ObjectTypes myType;
    public ObjectPooler objectpool;
    public event EventHandler OnCollection; // declare event

    public void ResetSubscriptions()
    {
        OnCollection = null;
    }

    // make method to call an event
    void RaiseSmashBox(CoinArgs args)
    {
        if (OnCollection != null)
            OnCollection.Invoke(this, args);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnCollection(this, EventArgs.Empty);
            objectpool.ReturnObject(this.gameObject, myType);
        }
    }

    public void SetObjectPool(ObjectPooler objectPooler)
    {
        objectpool = objectPooler;
    }
}
