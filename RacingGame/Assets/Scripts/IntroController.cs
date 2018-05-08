using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

	[SerializeField]
	private GameObject panelMainMenu, panelOptions;
	public GameObject PlayButton;
	
	[SerializeField]
	private Text text;	

	void Start () {
		EventSystem.current.firstSelectedGameObject = PlayButton;
		EventSystem.current.SetSelectedGameObject(PlayButton);
		panelMainMenu.SetActive(true);
		panelOptions.SetActive(false);
	}

	public void Play(string nameOfScene) {
		Debug.Log("Go to PlayScene");
		 SceneManager.LoadScene(nameOfScene);
	}

	public void Options() {
		Debug.Log("Options");
		panelMainMenu.SetActive(false);
		panelOptions.SetActive(true);
	}
	public void BackToMain()
	{
		panelMainMenu.SetActive(true);
		panelOptions.SetActive(false);
	}
	public void SetGraphics(float value)
	{
		if(value == 0)
		{
			text.text = "Low"; 
			 QualitySettings.SetQualityLevel(0,true);
		}else if(value == 1)
		{
			text.text = "Medium"; 
			 QualitySettings.SetQualityLevel(1,true);
		}else if(value == 2)
		{
			text.text = "Ultra"; 
			 QualitySettings.SetQualityLevel(2,true);
		}
		string[] levels = QualitySettings.names;
		Debug.Log("Quality level "+levels[QualitySettings.GetQualityLevel()]);
	}
	public void Quit() {
		Application.Quit();
	}
}
