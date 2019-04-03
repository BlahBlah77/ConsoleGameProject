using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Collision : MonoBehaviour, IPlayerDamageable
{
    public EventManager eventmanager;
    public float currentHealth;
    private float maxHealth = 100;
    public Int_Stat_Script playerHealth;
    public Int_Stat_Script playerDefence;
    public AudioClip playerHurt;
    AudioSource audSource;

    private void Awake()
    {
        audSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        eventmanager.OnAnyHealthPackCollected += Eventmanager_OnAnyHealthPackCollected;
    }

    // if the player collects the pickup for health give them back 5 health
    private void Eventmanager_OnAnyHealthPackCollected(object sender, EventArgs e)
    {
        if (currentHealth <= maxHealth)
        {
            Debug.Log("adding five health");
            playerHealth.IntPlusChanger(5);
        }

        if (currentHealth == maxHealth)
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPickupable>() != null)
        {
            other.GetComponent<IPickupable>().Interact();
        }
    }


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

    void SetPlayerHealth()
    {
        currentHealth = maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
    }


    public void DamageTaken(float damage)
    {
        throw new System.NotImplementedException();
    }


    void IPlayerDamageable.PlayerTakesDamage(float damage)
    {
        int newDamage = (int)damage - playerDefence.runVariable;
        if (newDamage > 0) newDamage = 0;
        playerHealth.IntMinusChanger(newDamage);
        audSource.clip = playerHurt;
        audSource.Play();
        //UpdatePlayerHealth(damage);
    }
}
