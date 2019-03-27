using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Scrolling : MonoBehaviour {

    public float speed;
    public Vector3 endLoopPoint;
    public Vector3 startLoopPoint;
	
	void Update ()
    {
        transform.Translate(0, 0, -speed);
        if (transform.position.z <= endLoopPoint.z)
        {
            transform.position = startLoopPoint;
        }
	}
}
