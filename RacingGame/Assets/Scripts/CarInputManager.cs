using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputManager : MonoBehaviour {

    bool canMove = false;
    
    [SerializeField]
    string HorizontalName;
    public float Horizontal;

    [SerializeField]
    string VeritcalName;
    public float Vertical;

    [SerializeField]
    TrafficLightController raceStarter;

	void Start () {
        raceStarter.OnRaceStart += validateMovement;
	}
	
	void Update () {
        if(!canMove) return;

        Horizontal = Input.GetAxis(HorizontalName);
        Vertical = Input.GetAxis(VeritcalName);
	}
    void validateMovement()
    {
        canMove = true;
    }
}
