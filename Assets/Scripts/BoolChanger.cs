using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolChanger : StateMachineBehaviour {

    public string paramName;
    public bool currentBool;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(paramName, currentBool);
    }
}
