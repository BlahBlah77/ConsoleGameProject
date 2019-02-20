using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Enemy_Control : Base_Enemy_Control
{
    private void Update()
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
    public override void Attack()
    {
        //WHEN HEALTH IMPLEMENTED
        return;
    }
}
