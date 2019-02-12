using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamRotation : MonoBehaviour {

    public GameObject player;
    public float horizontalMouseSpeed;
    public float verticalMouseSpeed;
    private float yAxis;
    private float xAxis;

    void UpdateMouseRotation()
    {
        yAxis += horizontalMouseSpeed * Input.GetAxis("Mouse X");
        xAxis -= verticalMouseSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(xAxis, yAxis, 0.0f);
        this.transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateMouseRotation();
	}


}
