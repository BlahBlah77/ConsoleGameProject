using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Complex : MonoBehaviour {

    public float amplificationFactor = 0.5f;
    public float frequencyFactor = 1.0f;
    public float degreesFactor = 15.0f;
    public Vector3 rotationFactor = new Vector3(15, 30, 45);

    public Vector3 posOffset;
    public Vector3 posTemp;

    private void Start()
    {
        posOffset = transform.localPosition;
    }

    private void Update()
    {
        transform.Rotate(rotationFactor * Time.deltaTime);
        posTemp = posOffset;
        posTemp.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequencyFactor) * amplificationFactor;
        transform.localPosition = posTemp;
    }
}
