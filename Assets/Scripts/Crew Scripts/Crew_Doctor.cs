using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Doctor : Crew {

	//Canvas GameObjects for chatbox
	public GameObject TextBox;
	public GameObject Sprite;
	// Use this for initialization
	void Start () {
		// Set the visibility of the sprite and textbox to false
		TextBox.SetActive (false);
		Sprite.SetActive (false);
	}

	void OnMouseDown()
	{
		// Activate the sprite and corresponding TextBox to be visible when the crew member is clicked on.
		print ("Doctor Selected");
		Sprite.SetActive (true);
		TextBox.SetActive (true);
		//Saves selected crew for dialogue purposes
		selectedCrew = this.name;
	}

	public void DisplayText() {
		if (selectedCrew == "Doctor") {
			DialogueText.SetActive (true);
		}
	}
}