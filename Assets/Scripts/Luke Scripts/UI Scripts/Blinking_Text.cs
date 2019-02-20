using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking_Text : MonoBehaviour {
	
	void OnEnable () 
	{
		//Initiates text fade IEnumerator
		StartCoroutine(Fadetozero(1f, GetComponent<Text>()));
	}

	public IEnumerator Fadetozero(float timer, Text tex)
	{
		//Sets the text colour to a new colour, whose alpha is reduced over time until it is equal to zero
		tex.color = new Color (tex.color.r, tex.color.g, tex.color.b, 1);
		while (tex.color.a > 0.0f) 
		{
			tex.color = new Color (tex.color.r, tex.color.g, tex.color.b, tex.color.a - (Time.deltaTime / timer));
			yield return null;
		}
		//Starts the text fade to full IEnumerator
		StartCoroutine(Fadetofull(1f, GetComponent<Text>()));
	}

	public IEnumerator Fadetofull(float timer, Text tex)
	{
		//Sets the text colour to a new colour, whose alpha is increased over time until it is equal to 1
		tex.color = new Color (tex.color.r, tex.color.g, tex.color.b, 0);
		while (tex.color.a < 1.0f) 
		{
			tex.color = new Color (tex.color.r, tex.color.g, tex.color.b, tex.color.a + (Time.deltaTime / timer));
			yield return null;
		}
		//Initiates text fade IEnumerator
		StartCoroutine(Fadetozero(1f, GetComponent<Text>()));
	}
}
