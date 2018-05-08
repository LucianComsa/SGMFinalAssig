using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPanel : MonoBehaviour {


	Text textUI;
	public CarEngine car;

	void Start () {
		textUI = GetComponent<Text>();
		car.OnMove += UpdateSpeed;
	}

	void UpdateSpeed(float speed){
		textUI.text = (speed.ToString("00") + " km/H");
	}
}
