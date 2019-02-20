using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleProjectile_Enemy_Control : Base_Enemy_Control {

    public Transform firePoint;
    public GameObject projectileObject;
    public float fireAngle;

	// Update is called once per frame
	void Update ()
    {
        switch (state)
        {
            case AI_BehaveState.Idle:
                break;
            case AI_BehaveState.Chase:
                PursueBehaviour();
                break;
            case AI_BehaveState.Patrol:
                PatrolBehaviour();
                break;
            case AI_BehaveState.Search:
                SeekBehaviour();
                break;
        }
    }

    public override void PursueBehaviour()
    {
        navAgent.speed = patrolSpeed;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            Vector3 plaVec = playerPosition.position - transform.position;
            Quaternion playerRotateValue = Quaternion.LookRotation(plaVec);
            transform.rotation = playerRotateValue;
        }
        navAgent.destination = playerPosition.position;

        if (Time.time > fireTime)
        {
            Attack();
            fireTime = Time.time + fireRate;
        }
    }

    public override void Attack()
    {
        var obj = Instantiate(projectileObject, firePoint.position, firePoint.rotation);

        //calculates space inbetween player and firepoint
        float aim = Vector3.Distance(firePoint.position, playerPosition.position);

        //Calculates the required velocity Y and Z values using the distance inbetween the objects,
        //The current gravity and the angle that the angle the projectile will fire from
        float tempval1 = Mathf.Sqrt(aim * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * fireAngle * 2)));
        float velocy, velocz;
        velocy = tempval1 * Mathf.Sin(Mathf.Deg2Rad * fireAngle);
        velocz = tempval1 * Mathf.Cos(Mathf.Deg2Rad * fireAngle);
        Vector3 lv = new Vector3(0.0f, velocy, velocz);
        Vector3 gv = transform.TransformVector(lv);

        //Adds the force to the projectile
        obj.GetComponent<Rigidbody>().velocity = gv;
    }
}
