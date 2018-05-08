using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficLightController : MonoBehaviour {

	[SerializeField]
	private Light lightRed,lightYellow, lightGreen;
	[SerializeField]
	private RaceSceneManagerScript managerScript;
	public event Action OnRaceStart = delegate {};
	// Use this for initialization
	void Start () {
	}
	void Awake()
	{
		lightRed.enabled = false;
		lightYellow.enabled = false;
		lightGreen.enabled = false;
		managerScript.OnRaceSceneStart += startCountDown;
	}
	// Update is called once per frame
	void Update () {
		
	}
	private void toggleLightBulb(Light light)
	{
		light.enabled = !light.enabled;
	}
	public IEnumerator ControlLights()
	{
		toggleLightBulb(lightRed);
		yield return new WaitForSeconds(1);
		toggleLightBulb(lightYellow);
		yield return new WaitForSeconds(1);
			toggleLightBulb(lightRed);
		toggleLightBulb(lightYellow);
		toggleLightBulb(lightGreen);
		yield return new WaitForSeconds(1);
		toggleLightBulb(lightGreen);
		OnRaceStart();
		yield return null;

	}
	private void startCountDown()
	{
		StartCoroutine(ControlLights());
	}
}
