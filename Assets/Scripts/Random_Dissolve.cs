using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Dissolve : MonoBehaviour {

    Renderer rend;
	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float rand1 = Random.Range(0.0f, 1.0f);
        float rand2 = Random.Range(0.0f, 1.0f);
        float rand3 = Random.Range(0.0f, 1.0f);
        rend.material.color = new Color(rand1, rand2, rand3);
        rend.material.SetColor("_DissColor", new Color(rand1, rand2, rand3));
        rend.material.SetFloat("_DissAmount", rand1);
	}
}
