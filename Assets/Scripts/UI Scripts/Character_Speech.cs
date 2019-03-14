using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Speech : MonoBehaviour {

    bool playerSighted;
    public Dialogue_Segment characterSpeech;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerSighted = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerSighted = false;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Dialogue_Manager.Instance.DialogueStart(characterSpeech);
            }
        }
    }
}
