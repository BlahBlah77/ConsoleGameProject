using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Base_Enemy_Control : MonoBehaviour, IDamageable {

    public Transform playerPosition;
    public NavMeshAgent navAgent;
    public Sight_Trigger coneSight;
    public Vector3 playerKnownPos;

    public AI_BehaveState state;

    public float rayLength = 20.0f;
    public float rayLengthAttack = 3.0f;

    public float fireRate = 3.0f;
    public float fireTime;

    public float patrolSpeed = 3.0f;
    public Transform[] patrolPointList;
    int patrolCurrentPoint;

    public Animator anim;
    bool isAttacking = false;

    public Material deathMat;
    public Renderer rend;

    public bool instaAgro;
    public bool animations;
    bool isDead = false;

    
    public AudioSource audSource;
    public AudioClip[] zombieDeaths;


    //set all the data for enemies here
    [SerializeField] EnemyData _enemyDataScriptableObject;

    // shows the enemy's current stat for the data, reset everytime 
    [SerializeField] public EnemyDataclass _enemyData;

    [SerializeField] internal float currentHealth;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        audSource = GetComponent<AudioSource>();
        _enemyData = _enemyDataScriptableObject._enemyData;
        currentHealth = _enemyData.EnemyHealth;
        if (anim == null && animations)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Use this for initialization
    void Start ()
    {
        // get an array of the two sounds
        audSource.clip = zombieDeaths[UnityEngine.Random.Range(0, zombieDeaths.Length)];


        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        coneSight = GetComponentInChildren<Sight_Trigger>();
        navAgent.stoppingDistance = 0.2f;
        if (patrolPointList.Length != 0)
        {
            state = AI_BehaveState.Patrol;
            if (animations) anim.SetBool("isIdle", false);
        }
        else
        {
            state = AI_BehaveState.Idle;
            if (animations) anim.SetBool("isIdle", true);
        }//anim.SetBool

        if (instaAgro)
        {
            navAgent.stoppingDistance = 2.0f;
            state = AI_BehaveState.Chase;
        }
    }

    public void PatrolBehaviour()
    {
        RaycastHandler();
        navAgent.speed = patrolSpeed;
        if (navAgent.remainingDistance < navAgent.stoppingDistance)
        {
            if (patrolCurrentPoint == patrolPointList.Length - 1)
            {
                patrolCurrentPoint = 0;
            }
            else
            {
                patrolCurrentPoint++;
            }
        }
        navAgent.destination = patrolPointList[patrolCurrentPoint].position;
    }

    public virtual void IdleBehaviour()
    {
        RaycastHandler();
    }

    public virtual void PursueBehaviour()
    {
        navAgent.speed = patrolSpeed;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (animations) anim.SetBool("isIdle", true);
            Vector3 plaVec = playerPosition.position - transform.position;
            Quaternion playerRotateValue = Quaternion.LookRotation(plaVec);
            transform.rotation = new Quaternion(0, playerRotateValue.y, 0, playerRotateValue.w);
            if (Time.time > fireTime)
            {
                Attack();
                Debug.Log("Hung up on this line");
                fireTime = Time.time + fireRate;
            }
        }
        else
        {
            if (animations) anim.SetBool("isIdle", false);
        }
        navAgent.destination = playerPosition.position;
    }

    public void SeekBehaviour()
    {
        RaycastHandler();
        navAgent.destination = playerKnownPos;
        if (navAgent.remainingDistance < navAgent.stoppingDistance)
        {
            navAgent.destination = patrolPointList[patrolCurrentPoint].position;
            navAgent.stoppingDistance = 0.2f;
            state = AI_BehaveState.Patrol;
        }
    }

    public abstract void Attack();

    public virtual void RaycastHandler()
    {
        RaycastHit rayHit;
        if (coneSight.playerSpotted)
        {
            if (Physics.Linecast(transform.position, playerPosition.position, out rayHit))
            {
                if (rayHit.transform.gameObject.CompareTag("Player"))
                {
                    playerKnownPos = playerPosition.position;
                    if (rayHit.distance < 10)
                    {
                        navAgent.stoppingDistance = 2.0f;
                        state = AI_BehaveState.Chase;
                    }
                    else
                    {
                        state = AI_BehaveState.Search;
                    }
                }
            }
        }
    }

    void UpdateHealth(float value)
    {
        currentHealth -= value;

        // if the enemy health is zero.
        // set the health to zero
        // play their death animations...

        if (currentHealth <= 0)
        {
            KillEnemy();
        }

        Debug.Log("I took: " + value, this);
    }

    public IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
    [ContextMenu("Start Death")]
    public void KillEnemy()
    {
        currentHealth = 0;
        if (animations)
        {
            anim.SetTrigger("isDead");
            anim.SetBool("isDying", true);
            audSource.Play();

        }
        navAgent.isStopped = true;
        Debug.Log("Enemy Dead");
        //StartCoroutine(DeathTimer());
        StartCoroutine(BloodMaker(5.0f));
        isDead = true;
    }

    IEnumerator BloodMaker(float timer)
    {
        Debug.Log("He's Dead Jim");
        rend.material = deathMat;
        rend.material.SetFloat("_DissAmount", 0.0f);
        while (rend.material.GetFloat("_DissAmount") < 1.0f)
        {
            rend.material.SetFloat("_DissAmount", rend.material.GetFloat("_DissAmount") + (Time.deltaTime / timer));
            yield return null;
        }
        Destroy(gameObject);
        //yield new return WaitForSeconds
    }

    public void TakeDamage(float newDamage)
    {
        if (!isDead)
        {
            float damage = (newDamage + _enemyData.damageToTake) / 2;
            UpdateHealth(damage);
        }
    }

    public void AnimationTrigger()
    {
        if (animations) anim.SetTrigger("isTakingDamage");
    }
    
}
