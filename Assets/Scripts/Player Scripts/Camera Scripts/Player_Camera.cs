using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

	public float speed = 3.0f;
	public Vector3 camPos;
	[Header("Distance Values")]
	public float distance;
	public float minDist = 1f;
	public float maxDist = 4f;

	void Start () 
	{
		camPos = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}

	void Update()
	{
		CameraThree ();
	}

	void CameraThree()
	{
		Vector3 camPosDes = transform.parent.TransformPoint (camPos * maxDist);
		RaycastHit rayHit;

		if (Physics.Linecast (transform.parent.position, camPosDes, out rayHit)) 
		{
			distance = Mathf.Clamp (rayHit.distance * 0.5f, minDist, maxDist);
		} 
		else 
		{
			distance = maxDist;
		}

		transform.localPosition = Vector3.Lerp (transform.localPosition, camPos * distance, Time.deltaTime * speed);
	}

//	void CameraOne()
//	{
//		if (Input.GetAxis ("Camera Right") > 0)
//		{
//			offset = Quaternion.AngleAxis (1, Vector3.up) * offset;
//		}
//		if (Input.GetAxis ("Camera Left") > 0)	
//		{
//			offset = Quaternion.AngleAxis (1, Vector3.down) * offset;
//		}
//		transform.position = playerObj.transform.position + offset; 
//		transform.LookAt (playerObj.transform.position);
//	}
//
//	void CameraTwo()
//	{
//		horizontalInput = Input.GetAxis ("Mouse X");
//		verticalInput = Input.GetAxis ("Mouse Y");
//
//		if (horizontalInput > 0) 
//		{
//			offset = Quaternion.AngleAxis (1, Vector3.up* 5) * offset;
//		}
//		if (horizontalInput < 0) 
//		{
//			offset = Quaternion.AngleAxis (1, Vector3.down* 5) * offset;
//		}
//		if (verticalInput > 0) 
//		{
//			offset = Quaternion.AngleAxis (1, Vector3.right* 5) * offset;
//		}
//		if (verticalInput < 0) 
//		{
//			offset = Quaternion.AngleAxis (1, Vector3.left* 5) * offset;
//		}
//
//		//clampValue = Mathf.Clamp(clampValue - verticalMouse, -70, 50);
//		//Vector3 rotateValue = new Vector3 (clampValue, playerObj.transform.position.y, playerObj.transform.position.z);
//		//offset = new Vector3 (clampValue, offset.y, offset.z);
//
//		transform.position = playerObj.transform.position + offset; 
//		transform.LookAt (playerObj.transform.position);
//	}
}