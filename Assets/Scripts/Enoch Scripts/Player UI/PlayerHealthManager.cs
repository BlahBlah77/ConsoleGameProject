﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour, IDamager, IPlayerDamageable
{

    public Slider healthSlider;
    public float currentHealth;
    private float maxHealth = 100;
    float damageAmount;

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
        IDamageable Enemy = other.gameObject.GetComponent<IDamageable>();

        // if player collides with any of these enemies
        // the player will take damage based on what type of enemy it is.

        if (Enemy != null)
        {
            Enemy.TakeDamage(damageAmount);
        }
    }

    void UpdatePlayerHealth(float value)
    {
        currentHealth -= value;
    }


    public float DoDamage()
    {
        throw new System.NotImplementedException();
    }

    void IPlayerDamageable.PlayerTakesDamage(float damage)
    {
        UpdatePlayerHealth(damage);
    }
}
