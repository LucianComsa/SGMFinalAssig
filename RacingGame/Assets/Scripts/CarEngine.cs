using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarEngine : MonoBehaviour {
	float maxSpeed = 50f;
	float maxSpeedBackward = 7f;

	[SerializeField] 
	WheelCollider[] WheelColliders = new WheelCollider[4];
	[SerializeField] 
	GameObject[] WheelObjectsMesh = new GameObject[4];
	Quaternion[] WheelRotations;
	public event Action<WheelCollider[]> EngineEvent = delegate {};
	public event Action<float> OnMove = delegate{};
	
	[SerializeField] 
	Rigidbody carBody;
	AudioSource carEngineNoise;

	[SerializeField]
	GameObject gearBoxObject;
	CarGearBox gearBox;

	[SerializeField]
	GameObject pauseMenuGO;

	PauseMenuController pauseMenuController;

	void Start () {

		carEngineNoise = GetComponent<AudioSource> ();
		gearBox = gearBoxObject.GetComponent<CarGearBox> ();
		pauseMenuController = pauseMenuGO.GetComponent<PauseMenuController>();
		WheelRotations = new Quaternion[4];
		for (int i = 0; i < 4; i++)
		{
			WheelRotations[i] = WheelObjectsMesh[i].transform.localRotation;
		}
	}
	
	void Update () {
		if (pauseMenuController.isPaused) {
			gearBox.carPitch = 0;
			PlayCarEngineNoise();
			return;
		}

		if(carBody.velocity.magnitude != 0)
		{
			OnMove(getCarSpeed());
		}
		EngineEvent(WheelColliders);
		MoveCar(GetComponent<CarInputManager>().Vertical);
		TractionAdjustment(GetComponent<CarSteering>().Steering);
		UpdateWheelPositions();
		PlayCarEngineNoise();
		
	}
	void MoveCar(float vertical)
	{
		for (int i = 0; i < 4; i++) {
			WheelColliders [i].motorTorque = 1000f * vertical;
		}
		//clamp speed to a maximum of 200f (see maxSpeed variable)
		carBody.velocity = gearBox.isMovingForward ? 
			Vector3.ClampMagnitude (carBody.velocity, maxSpeed) : Vector3.ClampMagnitude (carBody.velocity, maxSpeedBackward);
	}
	public void TractionAdjustment(float steering)
	{
		if(carBody.velocity.magnitude > 5)
		{
			WheelColliders [0].motorTorque -= steering;
			WheelColliders [2].motorTorque -= steering/2;

			WheelColliders [1].motorTorque -= steering;
			WheelColliders [3].motorTorque -= steering/2;
			if(Mathf.Abs(steering) > 5)
			{
				GetComponent<CarPhysics>().ApplyGripToTrack(400f);
			} else
			{
				GetComponent<CarPhysics>().ApplyGripToTrack(270f);
			}
			
		}

	}
	public void UpdateWheelPositions()
	{
		for (int i = 0; i < 4; i++) {
			Quaternion quat;
			Vector3 position;
			WheelColliders [i].GetWorldPose (out position, out quat);
			WheelObjectsMesh [i].transform.position = position;
			WheelObjectsMesh [i].transform.rotation = quat;
		}
	}
	public float getCarSpeed()
	{
		//speed in km/h
		return carBody.velocity.magnitude * 3.6f;
	}
	
	public void PlayCarEngineNoise()
	{
		carEngineNoise.pitch = gearBox.carPitch;
	}
}
