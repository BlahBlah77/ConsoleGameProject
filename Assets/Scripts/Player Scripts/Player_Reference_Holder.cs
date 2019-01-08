﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Reference_Holder : MonoBehaviour {

	[Header("References")]
	public Player_Control_Ground_Check playerCGC;
	public Rigidbody rb;
	public Transform camTran;
	public Transform model; 

	// Use this for initialization
	void Start () 
	{
        camTran = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
		playerCGC = GetComponent<Player_Control_Ground_Check> ();
	}
}
