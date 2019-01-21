﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEvent : MonoBehaviour, IPoolableObject {

    public ObjectTypes myType;
    public ObjectPooler objectpool;
    public event EventHandler OnCollection; // declare event

    public bool isCollided = false;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isCollided)
            {
                //isCollided = true;
                OnCollection(this, EventArgs.Empty);
                objectpool.ReturnObject(this.gameObject, myType);
            }
        }
    }

    public void SetObjectPool(ObjectPooler objectPooler)
    {
        objectpool = objectPooler;
    }
}
