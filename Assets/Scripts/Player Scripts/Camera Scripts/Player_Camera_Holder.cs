using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Holder : MonoBehaviour {

	public float distance = 10.0f;
	float horizontalInput;
	float verticalInput;
	public float speed = 5.0f;
	public Transform playerObj;


	[Header("Clamp Values")]
	public float minClamp = -10;
	public float maxClamp = 70;

	void Start()
	{
		Vector3 tempEuler = transform.eulerAngles;
		horizontalInput = tempEuler.y;
		verticalInput = tempEuler.x;
	}

	void LateUpdate () 
	{
		if (playerObj) 
		{
			verticalInput += Input.GetAxis ("Mouse X") * speed * distance * Time.deltaTime;
			horizontalInput -= Input.GetAxis ("Mouse Y") * speed * Time.deltaTime;
			horizontalInput = Clamper (horizontalInput, minClamp, maxClamp);

			Quaternion rotat = Quaternion.Euler (horizontalInput, verticalInput, 0);

			Vector3 revDistance = new Vector3 (0, 0, -distance);
			Vector3 pos = rotat * revDistance + playerObj.position;

			transform.position = pos;
			transform.rotation = rotat;
		}
	}

	float Clamper(float ang, float min, float max)
	{
		if (ang < -360f)
			ang += 360f;
		if (ang > 360f)
			ang -= 360f;
		return Mathf.Clamp (ang, min, max);
	}
}
