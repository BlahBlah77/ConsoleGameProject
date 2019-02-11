using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Base_Enemy_Control : MonoBehaviour {

    public Transform playerPosition;
    public NavMeshAgent navAgent;
    public Sight_Trigger coneSight;
    public Vector3 playerKnownPos;

    public AI_BehaveState state;

    public float rayLength = 20.0f;
    public float rayLengthAttack = 3.0f;

    public float fireRate = 3.0f;
    private float fireTime;

    public float patrolSpeed = 3.0f;
    public Transform[] patrolPointList;
    int patrolCurrentPoint;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start ()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        coneSight = GetComponentInChildren<Sight_Trigger>();
        navAgent.stoppingDistance = 0.2f;
        state = AI_BehaveState.Patrol;
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

    public virtual void PursueBehaviour()
    {
        navAgent.speed = patrolSpeed;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            Vector3 plaVec = playerPosition.position - transform.position;
            Quaternion playerRotateValue = Quaternion.LookRotation(plaVec);
            transform.rotation = playerRotateValue;
            if (Time.time > fireTime)
            {
                Attack();
                fireTime = Time.time + fireRate;
            }
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
}
