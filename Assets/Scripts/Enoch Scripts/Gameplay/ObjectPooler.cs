using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectTypes { Breakable, Coin }

public class ObjectPooler : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject breakablePrefab;

    public static ObjectPooler objectPool; // create an instance of this and no need to reference
    public int pooledAmount = 1;
    public bool expandPool = true;    

    public List<GameObject> pooledCoins;
    public List<GameObject> pooledBreakables;

    public event EventHandler OnCoinSpawn;
    public event EventHandler OnBreakableSpawn;

    // Destroy unloads object from the memory and set reference to null so in order to use it again you need to recreate it, via let's say instantiate. 
    //Meanwhile SetActive just hides the object and disables all components on it so if you need you can use it again.



    void Awake()
    {
        // the current script is equals to everything in this script
        objectPool = this;
    }

    // Use this for initialization
    void Start()
    {
        foreach (GameObject breakableObj in pooledBreakables)
            breakableObj.GetComponent<IPoolableObject>().SetObjectPool(this);
        foreach (GameObject coinObj in pooledCoins)
            coinObj.GetComponent<IPoolableObject>().SetObjectPool(this);

        SeedList(breakablePrefab, pooledBreakables);
        SeedList(coinPrefab, pooledCoins);
    }
    public void ReturnObject(GameObject genericObject, ObjectTypes objectType)
    {
        switch (objectType) 
        {
            case ObjectTypes.Breakable:
                BreakableReturn(genericObject);
                break;
            case ObjectTypes.Coin:
                CoinReturn(genericObject);
                break;
            default:
                break;
        }
    }

    public void CoinReturn(GameObject returnedCoin)
    {
        returnedCoin.GetComponent<PickupEvent>().ResetSubscriptions();
        returnedCoin.SetActive(false);
        pooledCoins.Add(returnedCoin);
    }

    public GameObject GetCoin()
    {
        if(pooledCoins.Count == 0)
        {
            SeedList(coinPrefab, pooledCoins);
        }

        GameObject poppedCoin = pooledCoins[0];
        pooledCoins.RemoveAt(0);
        RaiseCoinSpawn(poppedCoin, EventArgs.Empty);
        poppedCoin.SetActive(true);
        return poppedCoin;
    }

    public void BreakableReturn(GameObject returnedBreakable)
    {
        returnedBreakable.GetComponent<PickupEvent>().ResetSubscriptions();
        returnedBreakable.SetActive(false);
        pooledCoins.Add(returnedBreakable);
    }

    public GameObject GetBreakable()
    {
        if (pooledBreakables.Count == 0)
        {
            SeedList(breakablePrefab, pooledBreakables);
        }

        GameObject poppedBreakable = pooledBreakables[0];
        pooledBreakables.RemoveAt(0);
        RaiseBreakableSpawn(poppedBreakable, EventArgs.Empty);
        poppedBreakable.SetActive(true);
        return poppedBreakable;
    }

    void SeedList (GameObject prefab, List<GameObject> poolList)
    {
        for (int x = 0; x < 4; x++)
        {
            GameObject newCoin = Instantiate(prefab);
            newCoin.GetComponent<IPoolableObject>().SetObjectPool(this);
            newCoin.SetActive(false);
            poolList.Add(newCoin);
        }
    }


    void RaiseBreakableSpawn(object spawnedBreakable, EventArgs args)
    {
        if (OnBreakableSpawn != null)
            OnBreakableSpawn.Invoke(spawnedBreakable, args);
    }

    void RaiseCoinSpawn(object spawnedCoin, EventArgs args)
    {
        if (OnCoinSpawn != null)
            OnCoinSpawn.Invoke(spawnedCoin, args);
    }

}

