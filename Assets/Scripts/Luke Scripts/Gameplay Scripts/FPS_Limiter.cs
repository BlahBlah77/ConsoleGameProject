using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Limiter : MonoBehaviour {

	public int fpslimit = 30;

	void Awake () 
	{
		//Sets the framerate of the application to the variable number
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = fpslimit;
	}

	void Update () 
	{
		//Ensures that the framerate remains at the variable number
		if (Application.targetFrameRate != fpslimit) 
		{
			Application.targetFrameRate = fpslimit;
		}
	}
}
