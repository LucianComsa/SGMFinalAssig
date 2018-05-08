using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RaceSceneManagerScript : MonoBehaviour {

	public event Action OnRaceSceneStart = delegate {};
	void Start () {
		OnRaceSceneStart();
	}

	public void Restart(){
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}

	public void ExitToMainMenu(){
		SceneManager.LoadScene(0);
	}

	public void QuitGame(){
		Application.Quit();
	}
	
}
