using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fighting : MonoBehaviour {

    int clickNum;
    bool isClickable;
    public Player_Reference_Holder playerRefs;

    private void Awake()
    {
        clickNum = 0;
        isClickable = true;
    }

    private void Start()
    {
        playerRefs = GetComponentInParent<Player_Reference_Holder>();
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            Comboer();
        }
	}

    void Comboer()
    {
        playerRefs.playerPCM.isAttacking = true;
        if(isClickable)
        {
            clickNum++;
        }
        if(clickNum == 1)
        {
            playerRefs.anim.SetInteger("AnimationInt", 1);
        }
    }

    public void CheckComboStatus()
    {
        isClickable = false;
        if(playerRefs.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clickNum == 1)
        {
            playerRefs.anim.SetInteger("AnimationInt", 0);
            isClickable = true;
            clickNum = 0;
        }
        else if (playerRefs.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clickNum >= 2)
        {
            playerRefs.anim.SetInteger("AnimationInt", 2);
            isClickable = true;
        }
        else if (playerRefs.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clickNum >= 2)
        {
            playerRefs.anim.SetInteger("AnimationInt", 0);
            isClickable = true;
            clickNum = 0;
        }
    }
}
