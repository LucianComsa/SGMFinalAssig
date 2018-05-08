using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearPanel : MonoBehaviour {
	
	[SerializeField]
	CarGearBox gearBox;

	Text textUI; 

	void Start () {
		textUI = GetComponent<Text>();
	}
	
	void Update () {
		textUI.text = "G:" + (gearBox.CurrentGear + 1);
	}
}
