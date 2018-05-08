using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour {
	float HEIGHT = 24f;

	[SerializeField]
	GameObject car;
	Rigidbody rb;

	void Start () {
		rb = car.GetComponent<Rigidbody>();
	}
	
	void Update () {
		if (rb == null) return;
			transform.position = (new Vector3(rb.transform.position.x, HEIGHT, rb.transform.position.z));		
	}
}
