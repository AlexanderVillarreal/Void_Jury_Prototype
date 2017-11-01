using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TeaspoonTools.TextboxSystem;

public class Crew_FirstMate : Crew {

	public GameObject textboxPrefab;

	public string textToDisplay;
	public Sprite portrait;

	bool displayingText = false;

	GameObject textbox = null;
	TextboxController textboxController = null;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		DeadCheck ();
	}

	/*void OnMouseDown() {
		Judgement ();
	}*/

	public void DisplayTextbox()
	{
		if (!displayingText) {
			displayingText = true;
			textbox = Textbox.Create (textboxPrefab, textToDisplay);
			textboxController = textbox.GetComponent<TextboxController> ();
			textbox.transform.SetParent (GameObject.Find ("Canvas").transform);

			textboxController.ChangePortrait (portrait);
			textboxController.PlaceOnScreen(new Vector2(0.5f, 0.15f));

			textboxController.DoneDisplayingText.AddListener (CloseTextbox);
			textboxController.StartShowingText ();
			textboxController.nameTagText = "Wieners";
		}
	}

	void OnMouseDown()
	{
		Debug.Log ("Displaying textbox!");
		DisplayTextbox ();
	}

	void CloseTextbox()
	{
		textboxController.Close ();
		textbox = null;
		displayingText = false;
	}
}
