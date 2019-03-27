using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve_Ball : MonoBehaviour {

    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Dissolve(0.5f));
    }

    IEnumerator Dissolve(float timer)
    {
        rend.material.SetFloat("_DissAmount", 0.0f);
        while (rend.material.GetFloat("_DissAmount") < 1.0f)
        {
            rend.material.SetFloat("_DissAmount", rend.material.GetFloat("_DissAmount") + (Time.deltaTime / timer));
            yield return null;
        }
        Destroy(gameObject);
    }

    void Update () {
		
	}
}
