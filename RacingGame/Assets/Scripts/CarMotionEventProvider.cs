using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMotionEventProvider : MonoBehaviour {
	//SINCE THE MOTOR CONTROLLS THE SPEED AND IT HAS A METHOD TO GET THE SPEED IN KM/H 
	//I ADDED THE EVENT TO THE ENGINE SCRIPT
	public event Action<float> OnMove = delegate{};
	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody>(); 
	}
	
	void Update () {
		if(rb.velocity.magnitude != 0)
			OnMove(rb.velocity.magnitude*3.6f);
	}
}
