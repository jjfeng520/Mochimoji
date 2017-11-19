using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour {

    public GameObject instructionPanel;

    void Start() 
	{
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2, 100, 40), "NEW GAME"))
		{
			SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
		}
        if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 + 60, 120, 40), "INSTRUCTIONS"))
        {
            instructionPanel.gameObject.SetActive(true);
        }
	}
}