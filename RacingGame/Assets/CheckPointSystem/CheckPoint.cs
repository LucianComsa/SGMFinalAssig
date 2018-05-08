using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class CheckPoint : MonoBehaviour {
		[HideInInspector]
		public string tagOfHit = "";
		MeshRenderer _mRenderer;
		public bool isActive { get; set; }

		void Start() {
			_mRenderer = GetComponent<MeshRenderer>();
			isActive = false;
		}

		void UpdateVisibility()
		{
			_mRenderer.enabled = isActive;
		}

		 void OnTriggerEnter(Collider other)
    	{
			if(other.gameObject.tag.StartsWith("Player"))
			{
				
				if(isActive)
				{
					tagOfHit = other.gameObject.tag;
				}
			}
    	}

		void Update() {
			UpdateVisibility();
		}
	}

