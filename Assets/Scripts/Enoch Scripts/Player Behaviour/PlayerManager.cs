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

    Rigidbody rb;
    public bool isIdle = false;
    public bool isRunning = false;
    public bool isTurning = false;

    int noofClicks;
    bool isClickable;



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
        noofClicks = 0;
        //rb = this.GetComponent<Rigidbody>();
        SetPlayerHealth();
        anim.SetBool("isIdle", true);
    }
	
	// Update is called once per frame
	void LateUpdate ()
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

        //Quaternion turn = Quaternion.Euler(0, playerRotation, 0);
        //rb.MoveRotation(rb.rotation * turn);

        this.transform.Translate(0, 0, playerMovement);
        this.transform.Rotate(0, playerRotation, 0);
        anim.SetFloat("speed", playerMovement);
        anim.SetFloat("turnspeed", playerRotation);

        // if we are moving forwards or backwards we play the running animation
        if (playerMovement != 0)
        {
            anim.SetBool("isIdle", false);
            isIdle = false;
            isRunning = true;
        }
        else
        {
            anim.SetBool("isIdle", true);
            isIdle = true;
            isRunning = false;
        }

        if (playerRotation != 0 && isIdle)
        {
            //anim.SetTrigger("Turning");
            Debug.Log("we are turning");
            isTurning = true;
        }
        else
        {
            //anim.SetBool("isIdle", true);
            isTurning = false;
        }

        // if we are running and we are not idle do not trigger the turn animation
        if (isRunning && !isIdle)
        {
            isTurning = false;
        }


        if ((Input.GetKeyDown(KeyCode.Space) && isRunning))
        {
            anim.SetTrigger("RunningJump");
            Debug.Log("Running Jump");
        }

        // if we are standing...
        if (playerMovement == 0)
        {
            Debug.Log("Player is standing");
            isIdle = true;
        }

        // play attack animation
        if (Input.GetMouseButtonDown(0) && !isIdle)
        {
            anim.SetTrigger("LightAttack");
            Debug.Log("Running Attack");
        }
        else if (Input.GetMouseButton(0) && isIdle)
        {
            anim.SetTrigger("StandingAttack");
            Debug.Log("Standing Attack");
        }

        // play standing jumping animation
        if (Input.GetKeyDown(KeyCode.Space) && isIdle)
        {
            anim.SetTrigger("StandingJump");
        }

        // set a heavy combo attack
        if (Input.GetMouseButtonDown(1))
        {
            //anim.SetTrigger("HeavyAttack");
            
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
