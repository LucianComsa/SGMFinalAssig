using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	public void SetVolume(float volume){
		audio.volume = volume;
	}
}
