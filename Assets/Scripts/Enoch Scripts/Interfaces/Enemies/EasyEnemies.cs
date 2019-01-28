using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemies : MonoBehaviour, IDamager, IDamageable {

    public float enemyHealth = 100;


    public float DoDamage()
    {
        float damageAmount = 5;

        return damageAmount;
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable player = collision.gameObject.GetComponent<IDamageable>();
        if (player != null)
        {
            Debug.Log("You are hit");
            player.TakeDamage(DoDamage());
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
