using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapPanel : MonoBehaviour {

	[SerializeField]
	CheckpointManager checkpointManager;
	Text textGO;

	void Start () {
		textGO = GetComponent<Text>();
		checkpointManager.OnLapFinished += UpdateLapPanel;
	}
	
	void UpdateLapPanel(int n){
		textGO.text = n.ToString() + " / 10";
	}
}
