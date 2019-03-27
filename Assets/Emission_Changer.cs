using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_Changer : MonoBehaviour {

    public Renderer rend;

    // Use this for initialization
    void Start ()
    {
		StartCoroutine(FlashOff(1.0f));
	}
	
    IEnumerator FlashOn(float timer)
    {
        while (rend.material.GetColor("Emission").a < 1.0f)
        {
            rend.material.SetFloat("Emission", rend.material.GetFloat("Emission") + (Time.deltaTime / timer));
            yield return null;
        }
        StartCoroutine(FlashOff(1.0f));
    }

    IEnumerator FlashOff(float timer)
    {
        while (rend.material.GetFloat("Emission") > 0.0f)
        {
            rend.material.SetFloat("Emission", rend.material.GetFloat("Emission") - (Time.deltaTime / timer));
            yield return null;
        }
        StartCoroutine(FlashOn(1.0f));
    }
}
