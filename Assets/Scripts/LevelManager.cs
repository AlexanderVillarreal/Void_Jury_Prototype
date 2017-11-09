using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	void Start ()
	{
		SceneManager.activeSceneChanged += ActivateUIElements;
	}

	public void ChangeToScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	void ActivateUIElements (Scene previousScene, Scene newScene)
	{
		if (newScene.name == "Jury_Scene")
		{
			print ("Scene Changed");
			print ("I'm serious, it changed");
			// Collect all of the UI elements that will hold "entries" of the clues you have found
			ClueManager._builtCluesMenu = GameObject.FindGameObjectsWithTag ("ClueEntry");
			// Activate each ClueEntry Object of the menu
			for (int i = 0; i < ClueManager._builtCluesMenu.Length; i++)
			{
				ClueManager._builtCluesMenu [i].SetActive (false);
			}
		}
	}
}
