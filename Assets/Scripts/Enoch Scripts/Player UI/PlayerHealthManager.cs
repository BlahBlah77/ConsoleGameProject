using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour, IDamager, IDamageable {

    public Slider healthSlider;
    public float currentHealth;
    private float maxHealth = 100;

    // getter and setter for damage taken
    public float getDamageTaken
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    public void DamageTaken(float damage)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start ()
    {
        SetPlayerHealth();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShowPlayerHealth();
        PlayerDead();
	}

    void SetPlayerHealth()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
    }

    void ShowPlayerHealth()
    {
        healthSlider.value = currentHealth;
    }

    void PlayerDead()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You die");
            // death animation here....
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 3 types of enemies that can damage the player
        IDamageable easyEnemies = other.gameObject.GetComponent<IDamageable>();
        IDamageable meduimEnemies = other.gameObject.GetComponent<IDamageable>();
        IDamageable hardEnemies = other.gameObject.GetComponent<IDamageable>();

        // if player collides with any of these enemies
        // the player will take damage based on what type of enemy it is.

        if (easyEnemies != null)
        {
            easyEnemies.TakeDamage(DoDamage());
        }

        if (meduimEnemies != null)
        {
            meduimEnemies.TakeDamage(DoDamage());
        }

        if (hardEnemies != null)
        {
            hardEnemies.TakeDamage(DoDamage());
        }

    }

    public float DoDamage()
    {
        // all attacking sword animation stuff 
        // will do damage to enemies so add.

        //Debug.Log("I have given: " + 10); 
        //return 10;

        return 10;
    }

    public void TakeDamage(float damage)
    {
        // player will take damage based on
        // what enemy is attacking it...

        currentHealth -= damage;
    }
}
