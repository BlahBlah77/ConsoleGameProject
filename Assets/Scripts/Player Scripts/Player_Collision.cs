using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour, IPlayerDamageable
{
    public float currentHealth;
    private float maxHealth = 100;
    public Int_Stat_Script playerHealth;

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

    //void UpdatePlayerHealth(float value)
    //{
    //    currentHealth -= value;
    //}

    void IPlayerDamageable.PlayerTakesDamage(float damage)
    {
        playerHealth.IntMinusChanger((int)damage);
        //UpdatePlayerHealth(damage);
    }
}
