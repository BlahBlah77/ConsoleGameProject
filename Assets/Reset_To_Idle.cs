using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_To_Idle : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<Player_Control_Movement>().isAttacking = false;
    }
}
