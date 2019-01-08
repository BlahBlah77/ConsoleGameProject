using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control_Movement : MonoBehaviour {

	[Header("Player Inputs")]
	float vertInput;
	float horiInput;

	[Header("Speed Values")]
	public float inputSpeed = 8.0f;
	public float maxSpeed = 15.0f;

	Player_Reference_Holder playerRefs;

	void Start () 
	{
		playerRefs = GetComponent<Player_Reference_Holder> ();
	}

	void Update () 
	{
		MovementInputRetrieve ();
		GroundMovement ();
	}

	void MovementInputRetrieve()
	{
		horiInput = Input.GetAxis ("Horizontal") * inputSpeed;
		vertInput = Input.GetAxis ("Vertical") * inputSpeed;
	}

	void GroundMovement()
	{
		Quaternion camQuad = playerRefs.camTran.transform.rotation;
		if ((horiInput != 0) || (vertInput != 0)) 
		{
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, camQuad.eulerAngles.y, transform.eulerAngles.z);
			playerRefs.rb.AddRelativeForce (new Vector3 (horiInput, 0.0f, vertInput), ForceMode.Impulse);
			//transform.localRotation = Quaternion.LookRotation (new Vector3(horiInput, 0.0f, vertInput), Vector3.up);
			playerRefs.model.localRotation = Quaternion.LookRotation (new Vector3(horiInput, 0.0f, vertInput), Vector3.up);
		}
		if (playerRefs.rb.velocity.magnitude > maxSpeed) 
		{
			playerRefs.rb.velocity = playerRefs.rb.velocity.normalized * maxSpeed;
		}
	}
}
