using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeScript : MonoBehaviour {

	[SerializeField]
	MeshRenderer BreakLights;
	CarEngine carEngineScript;
	CarInputManager carInputManagerScript;
	CarSteering carSteeringScript;
	CarPhysics carPhysicsScript;

	void Start () {
		carEngineScript = GetComponent<CarEngine>();
		carSteeringScript = GetComponent<CarSteering>();
		carPhysicsScript = GetComponent<CarPhysics>();
		carInputManagerScript = GetComponent<CarInputManager>();

		if (carEngineScript == null) return;
			carEngineScript.EngineEvent += ApplyABS;
	}

	public void ApplyABS(WheelCollider[] colliders)
	{
		float steering = carSteeringScript.Steering;
		colliders [0].motorTorque -= steering/2;
		colliders [2].motorTorque -= steering/2;

		colliders [1].motorTorque -= steering;
		colliders [3].motorTorque -= steering;

		carPhysicsScript.ApplyGripToTrack(200f);
	}

	public void BreakLightsCheck(float v)
	{
		ToggleBreakLight(!CheckCarMovementDirection (v));
	}

	bool CheckCarMovementDirection(float vertical)
	{
		return vertical >= 0;
	}

	public void ToggleBreakLight(bool on)
	{
		BreakLights.enabled = on;
	}

	void Update () {
		BreakLightsCheck(carInputManagerScript.Vertical);
	}
}
