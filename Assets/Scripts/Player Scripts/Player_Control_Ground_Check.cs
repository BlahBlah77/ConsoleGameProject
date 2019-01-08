using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control_Ground_Check : MonoBehaviour {

	public bool groundJump;
	public bool doubleJump;

	void FixedUpdate()
	{
		RaycastHit rayHit;

		//Capsule cast to check for objects of terrain tag, then 
		//Sets ground bool to true and other bools to false
		if (Physics.CapsuleCast(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z), 0.1f, -transform.up, out rayHit, 2.0f))
		{
			if (rayHit.transform.gameObject.tag == "Terrain")
			{
				groundJump = true;
				doubleJump = false;
			}
		}
		else
		{
			groundJump = false;
		}
	}
}
