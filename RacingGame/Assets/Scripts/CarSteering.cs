using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering : MonoBehaviour {

	public float Steering;
	[SerializeField]
	public float maxSteeringAngle = 45f;
	[SerializeField]
	Rigidbody rb;
	
	CarEngine carEngineScript;
	CarInputManager carInputManagerScript;

	void Start () {
		carEngineScript = GetComponent<CarEngine>();
		carInputManagerScript = GetComponent<CarInputManager>();
		rb = GetComponent<Rigidbody>();
		
		if (carEngineScript == null) return;
			carEngineScript.EngineEvent += SteerVehicle;
	}
	
	void Update () {
		float horizontal = carInputManagerScript.Horizontal;
		Steering = maxSteeringAngle * horizontal;
	}

	void SteerVehicle(WheelCollider[] colliders)
	{
		if (rb.velocity.magnitude > 5f) 
		{
			Steering = Steering * 4 / rb.velocity.magnitude;
		}
		colliders[0].steerAngle = Steering;
		colliders[2].steerAngle = Steering;
	}
}
