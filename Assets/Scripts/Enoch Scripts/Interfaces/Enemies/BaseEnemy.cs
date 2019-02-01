using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class BaseEnemy : MonoBehaviour, IDamager, IDamageable
{
    public Animator anim;
    bool isAttacking = false;

    //set all the data for enemies here
    [SerializeField] EnemyData _enemyDataScriptableObject;

    // shows the enemy's current stat for the data, reset everytime 
    [SerializeField]  private  EnemyDataclass _enemyData;

    private void Awake()
    {
        _enemyData = _enemyDataScriptableObject._enemyData;
    }

    public float DoDamage()
    {
        // how much damage did i do to the player
        // based on the type of animation I play (extension task)

        if (isAttacking)
        {
            anim.SetTrigger("attack");
        }

        return _enemyData.enemyAttackPower;
    }

    // Use this for initialization
    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
       // the enemy will check how much damage it needs to take
       // and takes the damage...
        UpdateHealth(_enemyData.damageToTake);
    }

    void UpdateHealth(float value)
    {
       
        _enemyData.EnemyHealth -= value;

        // if the enemy health is zero.
        // set the health to zero
        // play their death animations...

        if (_enemyData.EnemyHealth <= 0)
        {
            _enemyData.EnemyHealth = 0;
            anim.SetTrigger("Death");
            Debug.Log("Enemy Dead");
        }

        Debug.Log("I took: " + value, this);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if i hit anything that implemets the iDamageable
        IPlayerDamageable player = other.gameObject.GetComponent<IPlayerDamageable>();

        if (player != null)
        {
            Debug.Log("You are hit");
            player.PlayerTakesDamage(DoDamage()); // the player with the interface will take damage to its health
        }
    }
}





