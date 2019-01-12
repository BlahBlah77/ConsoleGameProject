using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour {

    public GameObject CoinTest;
    private float numberOfCoins;


    private void Start()
    {
        SetupSpawnedCoins();
    }

    void SetupSpawnedCoins()
    {
        CoinTest.GetComponent<Rigidbody>().useGravity = true;
        CoinTest.GetComponent<Collider>().isTrigger = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        numberOfCoins = Random.Range(1, 6);

        if (other.gameObject.tag == "Player")
        {
            for (int x = 0; x < numberOfCoins; x++)
            {
                Destroy(this.gameObject);
                Instantiate(CoinTest, transform.position, transform.rotation).GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 50);
            }
        }
    }
}
