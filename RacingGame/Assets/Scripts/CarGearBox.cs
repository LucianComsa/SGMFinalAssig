using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGearBox : MonoBehaviour {

	[SerializeField] 
	public int CurrentGear = 1;

	[SerializeField] 
	int[] Gears = new int[6];

	AudioSource carShiftNoise;

	public bool shouldChangeGear;

	[SerializeField] 
	public float carPitch;

	[SerializeField] 
	public Rigidbody carBody;

	CarInputManager carInputManagerScript;
	public bool isMovingForward;

	void Start () {

		carInputManagerScript = carBody.GetComponent<CarInputManager>();
		carShiftNoise = GetComponent<AudioSource>();
		carShiftNoise.volume = 0.3F;

		if(carBody == null)
		{
			carBody = GetComponent<Rigidbody>();
		}

		Gears = new int[] {10, 30, 50, 80, 110, 185};
	}
	void EngineGearBox()
	{
		float speed = getCarSpeed();
		int CurrentGearLocal = 1;
		for (int i = 0; i < Gears.Length; i++) {

			if (Gears [i] > speed) {
				CurrentGearLocal = i;
				break;
			}
			float gearMinValue = 0.0f;
			float gearMaxValue = 0.0f;
			if (i == 0) {
				gearMinValue = 0.0f;
				gearMaxValue = Gears [i];
			} 
			else {
				gearMinValue = Gears [i - 1];
				gearMaxValue = Gears [i];
			}
			carPitch = (speed - gearMinValue) / (gearMaxValue - gearMinValue);
			carPitch = 	carPitch * 0.4f;

		}
		if (CurrentGear != CurrentGearLocal) {
			CurrentGear = CurrentGearLocal;
			if (CurrentGear == 0 && carInputManagerScript.Vertical < 0) {
				isMovingForward = false;
			} else if(carInputManagerScript.Vertical > 0 && CurrentGear >= 0) {
				PlayVehicleSound ();
				isMovingForward = true;
			}
		}
	}
	float getCarSpeed()
	{
		//speed in km/h
		return carBody.velocity.magnitude * 3.6f;
	}

	void Update () {
		EngineGearBox();
	}

	void PlayVehicleSound()
	{
		carShiftNoise.Play();
	}
}
