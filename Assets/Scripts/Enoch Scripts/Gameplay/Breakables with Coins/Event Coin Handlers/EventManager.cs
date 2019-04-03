using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public event EventHandler OnAnySmashBox;
    public event EventHandler OnAnyCoinCollected;
    public event EventHandler OnAnyHealthPackCollected;
    public ObjectPooler objectPooler;

    // Use this for initialization
    void Start ()
    {

        objectPooler.OnCoinSpawn += ObjectPooler_OnCoinSpawn;

        objectPooler.OnHealthSpawn += ObjectPooler_OnHealthPackSpawn;


        PickupEvent[] breakableObjects = GameObject.FindObjectsOfType<PickupEvent>();
        foreach(PickupEvent aBreakableObject in breakableObjects)
        {
            aBreakableObject.OnCollection += ABreakableObject_OnSmashBox;// subscribes to the onsmashbox from other script            
        }
    }

    private void OnDestroy()
    {
        objectPooler.OnCoinSpawn -= ObjectPooler_OnCoinSpawn;

        objectPooler.OnHealthSpawn -= ObjectPooler_OnHealthPackSpawn;

        PickupEvent[] breakableObjects = GameObject.FindObjectsOfType<PickupEvent>();
        foreach (PickupEvent aBreakableObject in breakableObjects)
        {
            aBreakableObject.OnCollection -= ABreakableObject_OnSmashBox;// subscribes to the onsmashbox from other script            
        }
    }

    private void ObjectPooler_OnCoinSpawn(object sender, EventArgs e)
    {
        GameObject spawnedCoin = sender as GameObject;
        spawnedCoin.GetComponent<PickupEvent>().OnCollection += EventManager_OnCollection;
    }

    private void ObjectPooler_OnHealthPackSpawn(object sender, EventArgs e)
    {
        GameObject spawnedHealthPack = sender as GameObject;
        spawnedHealthPack.GetComponent<PickupEvent>().OnCollection += EventManager_OnCollection;
    }

    private void EventManager_OnCollection(object sender, EventArgs e)
    {
        RaiseAnyCoinCollected(EventArgs.Empty);
        RaiseAnyHealthPackCollected(EventArgs.Empty);
    }

    // a new method that can check all boxes and doing its own event for that
    void RaiseAnySmashBox(EventArgs args)
    {
        if (OnAnySmashBox != null)
            OnAnySmashBox.Invoke(this, args);
    }

    // a new method that can check all boxes and doing its own event for that
    void RaiseAnyCoinCollected(EventArgs args)
    {
        if (OnAnyCoinCollected != null)
            OnAnyCoinCollected.Invoke(this, args);
    }

    void RaiseAnyHealthPackCollected(EventArgs args)
    {
        if (OnAnyHealthPackCollected != null)
            OnAnyHealthPackCollected.Invoke(this, args);
    }

    // the recieving function that gets called when a box is smashed
    private void ABreakableObject_OnSmashBox(object sender, EventArgs e)
    {
        print("Smashed Box: " + sender);
        RaiseAnySmashBox(e);
    }
}
