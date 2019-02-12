using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerManager : MonoBehaviour, IDamager, IPlayerDamageable
{
    public Animator anim;
    public Slider healthSlider;
    public float currentHealth;
    private float maxHealth = 100;
    private float damageAmount;
    private float playerMovement;
    private float playerRotation;
    public float playerSpeed;
    public float playerRotationSpeed;
    public bool isAttacking = false;



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
        anim = GetComponent<Animator>();
        SetPlayerHealth();
        anim.SetBool("isIdle", true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShowPlayerHealth();
        PlayerDead();
        PlayerActions();
    }

    void PlayerActions()
    {
        playerMovement = Input.GetAxis("Vertical") * playerSpeed;
        playerRotation = Input.GetAxis("Horizontal") * playerRotationSpeed;

        playerMovement *= Time.deltaTime;
        playerRotation *= Time.deltaTime;

        this.transform.Translate(0, 0, playerMovement);
        this.transform.Rotate(0, playerRotation, 0);

        //set the player running forwards...
        if (playerMovement > 0)
        {
            anim.SetBool("isRunningForwards", true);
        }
        else
        {
            anim.SetBool("isRunningForwards", false);
        }

        // set the player running backwards
        if (playerMovement < 0)
        {
            anim.SetBool("isRunningBackwards", true);
        }
        else
        {
            anim.SetBool("isRunningBackwards", false);
            if (isAttacking) return;
        }

        // play attack animation
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

        // set a heavy combo attack
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("HeavyAttack");
        }

        // play jumping animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jumping");
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

    void PlayerDead()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentHealth -= 10; 
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You die");
            anim.SetBool("isDead", true); // death animation here....
            this.GetComponent<Rigidbody>().freezeRotation = true;
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
