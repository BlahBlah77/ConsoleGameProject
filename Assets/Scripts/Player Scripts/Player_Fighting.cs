using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fighting : MonoBehaviour {

    [SerializeField] int clickNum;
    [SerializeField] bool isClickable;
    public Player_Reference_Holder playerRefs;
    public List<BoxCollider> weapons;
    bool isBlocking;

    public AudioClip swrdSlash1;
    public AudioClip swrdSlash2;
    AudioSource audSource;

    private void Awake()
    {
        audSource = GetComponent<AudioSource>();
        clickNum = 0;
        isClickable = true;
    }

    private void Start()
    {
        playerRefs = GetComponent<Player_Reference_Holder>();
        DisableBox();
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            audSource.clip = swrdSlash1;
            audSource.Play();
            EnableBox();
            Comboer();
        }

        SingleAttacks();
    }

    void SingleAttacks()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerRefs.playerPCM.isRunning)
        {
            audSource.clip = swrdSlash2;
            audSource.Play();
            EnableBox();
            playerRefs.anim.SetTrigger("SlideAttack");
        }

        if (Input.GetMouseButtonDown(1) && playerRefs.playerPCM.isIdle)
        {
            audSource.clip = swrdSlash2;
            audSource.Play();
            EnableBox();
            Debug.Log("Right Mouse Clicked");
            playerRefs.anim.SetTrigger("HeavySpinAttack");
        }

        if (Input.GetMouseButtonDown(1) && playerRefs.playerPCM.isRunning)
        {
            audSource.clip = swrdSlash2;
            audSource.Play();
            EnableBox();
            Debug.Log("Right Mouse Clicked");
            playerRefs.anim.SetTrigger("HeavySpinAttack");
            playerRefs.playerPCM.isIdle = false;
        }


        // blocking
        if (Input.GetKey(KeyCode.V) && playerRefs.playerPCM.isIdle)
        {
            playerRefs.anim.SetTrigger("isBlocking");
            isBlocking = true;
            Debug.Log("Blocking");
        }
        else
        {
            isBlocking = false;
        }
    }

    void Comboer()
    {
        if(isClickable)
        {
            clickNum++;
        }
        if(clickNum >= 1 && playerRefs.anim.GetInteger("AnimationInt") == 0)
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

    void EnableBox()
    {
        foreach (BoxCollider box in weapons)
        {
            if (box.gameObject.activeSelf)
            {
                box.enabled = true;
            }
        }
    }

    public void DisableBox()
    {
        Debug.Log("Disabled");
        foreach (BoxCollider box in weapons)
        {
            if (box.gameObject.activeSelf)
            {
                box.enabled = false;
            }
        }
    }
}
