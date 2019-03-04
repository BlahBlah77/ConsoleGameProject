using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fighting : MonoBehaviour {

    [SerializeField] int clickNum;
    [SerializeField] bool isClickable;
    public Player_Reference_Holder playerRefs;
    public Player_Control_Movement playerMov;

    private void Awake()
    {
        clickNum = 0;
        isClickable = true;
    }

    private void Start()
    {
        playerRefs = GetComponent<Player_Reference_Holder>();
        playerMov = GetComponent<Player_Control_Movement>();
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            Comboer();
        }

        SingleAttacks();
    }

    void SingleAttacks()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerMov.isRunning)
        {
            playerRefs.anim.SetTrigger("SlideAttack");
        }

        if (Input.GetMouseButtonDown(1) && playerMov.isIdle)
        {
            Debug.Log("Right Mouse Clicked");
            playerRefs.anim.SetTrigger("HeavySpinAttack");
        }

        if (Input.GetMouseButtonDown(1) && playerMov.isRunning)
        {
            Debug.Log("Right Mouse Clicked");
            playerRefs.anim.SetTrigger("HeavySpinAttack");
            playerMov.isIdle = false;
        }
    }

    void Comboer()
    {
        if(isClickable)
        {
            clickNum++;
        }
        if(clickNum == 1 && playerRefs.anim.GetInteger("AnimationInt") == 0)
        {
            playerRefs.anim.SetInteger("AnimationInt", 1);
        }
    }

    public void ClickReset()
    {
        clickNum = 0;
    }

    public void CheckComboStatus()
    {
        isClickable = false;
        if(playerRefs.anim.GetInteger("AnimationInt") == 1 && clickNum == 0)
        {
            playerRefs.anim.SetInteger("AnimationInt", 0);
        }
        else if (playerRefs.anim.GetInteger("AnimationInt") == 1 && clickNum >= 1)
        {
            playerRefs.anim.SetInteger("AnimationInt", 2);
        }
        else if (playerRefs.anim.GetInteger("AnimationInt") == 2 && clickNum == 0)
        {
            playerRefs.anim.SetInteger("AnimationInt", 0);
        }
        else if (playerRefs.anim.GetInteger("AnimationInt") == 2 && clickNum >= 1)
        {
            playerRefs.anim.SetInteger("AnimationInt", 3);
        }
        else if (playerRefs.anim.GetInteger("AnimationInt") == 3 && clickNum >= 0)
        {
            playerRefs.anim.SetInteger("AnimationInt", 0);
        }
        isClickable = true;
    }
}
