using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduimEnemies : MonoBehaviour, IDamager, IDamageable
{
    public float meduimEnemyHealth = 100;
    public float damageAmount = 10f;
    float damageReduction = 5f;

    public float DoDamage()
    {
        // how much damage did i do to the player
        // based on the type of animation I play (extension task)
        return damageAmount;
    }

    public void TakeDamage(float damage)
    {
        // this checks how much damage would be taken
        // if hit by something in the game...
        damage -= damageReduction;

        if (damage <= 0)
        {
            damage = 0;
        }

        meduimEnemyHealth -= damage;

    }

    private void OnTriggerEnter(Collider other)
    {
        // if i hit anything that implemets the iDamageable
        IDamageable player = other.gameObject.GetComponent<IDamageable>();
        if (player != null)
        {
            Debug.Log("You are hit");
            player.TakeDamage(DoDamage()); // the player with the interface will take damage to its health
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
