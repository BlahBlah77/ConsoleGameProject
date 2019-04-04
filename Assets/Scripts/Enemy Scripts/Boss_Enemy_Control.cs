using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enemy_Control : Base_Enemy_Control, IDamager
{
    public FinalBossUIManager bossUIRef;

    private void Update()
    {
        switch (state)
        {
            case AI_BehaveState.Idle:
                IdleBehaviour();
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
    public float DoDamage()
    {
        return _enemyData.enemyAttackPower;
    }

    public override void Attack()
    {
        RaycastHit attackHit;
        Ray newRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(newRay, out attackHit, rayLengthAttack))
        {
            int randnum = Random.Range(0, 5);
            anim.SetInteger("AttackNum", randnum);
            anim.SetTrigger("isAttacking");
        }
    }

    public void ActualAttack()
    {
        RaycastHit attackHit;
        Ray newRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(newRay, out attackHit, rayLengthAttack))
        {
            IPlayerDamageable player = attackHit.transform.GetComponent<IPlayerDamageable>();
            if (player != null)
            {
                player.PlayerTakesDamage(DoDamage()); // the player with the interface will take damage to its health
                Debug.Log("Attack Successful");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }

    public void DeathTrigger()
    {
        bossUIRef.EnableUIPanel(bossUIRef.victoryPanel);
    }

}
