using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_To_Idle : StateMachineBehaviour {

    public bool boolChange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Player_Control_Movement>().isAttacking = boolChange;
    }
}
