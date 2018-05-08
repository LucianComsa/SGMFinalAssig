using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPhysics : MonoBehaviour {

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	public void ApplyGripToTrack(float downforce)
	{
		rb.AddForce (-transform.up * downforce * rb.velocity.magnitude);
	}
}
