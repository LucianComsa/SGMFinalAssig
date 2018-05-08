using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour{
	Stack<GameObject> menuStack = new Stack<GameObject>();
	
	[SerializeField]
	GameObject PauseMenuCanvas;
	public bool isPaused;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!ShowPauseMenuIfNoActiveMenu())
				MenuDisappear();
		}		
	}

    bool ShowPauseMenuIfNoActiveMenu()
    {
		isPaused = true;
        if(menuStack.Count == 0){
			PauseMenuCanvas.SetActive(true);
			menuStack.Push(PauseMenuCanvas);	
			Time.timeScale = 0f;
			return true;			
		}
		return false;
    }

    public void MenuAppear(GameObject menu){
		menuStack.Peek().SetActive(false);
		menu.SetActive(true);
		menuStack.Push(menu);
	}

	public void MenuDisappear(){
		isPaused = false;
		menuStack.Pop().SetActive(false);
		if(menuStack.Count == 0)
			Time.timeScale = 1f;
		else
			menuStack.Peek().SetActive(true);
		
	}

}
