using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour, IDamager, IDamageable {

    public Slider healthSlider;
    public float currentHealth;
    private float maxHealth = 100;
    bool canTakeDamage;

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
        PressToDie();
	}

    void OnTriggerEnter(Collider other)
    {
        IDamageable meduimDamageObj = other.gameObject.GetComponent<IDamageable>();

        if (meduimDamageObj != null)
        {
            meduimDamageObj.TakeDamage(DoDamage());
        }

    }


    void PressToDie()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentHealth--;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You die");
        }
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

    public float DoDamage()
    {
        // all attacking sword animation stuff 
        // will do damage to enemies so add.

        Debug.Log("I have given: " + 10);
        return 10;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
