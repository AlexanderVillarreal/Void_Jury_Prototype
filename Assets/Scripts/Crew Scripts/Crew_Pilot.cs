using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Pilot : Crew {

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
		if (AccusationManager.S.selectedCrew == "") {
			// Activate the sprite and corresponding TextBox to be visible when the crew member is clicked on.
			print ("Pilot Selected");
			Sprite.SetActive (true);
			TextBox.SetActive (true);
			//Saves selected crew for dialogue purposes
			AccusationManager.S.selectedCrew = this.name;
		}
	}

	public void DisplayText() {
		if (AccusationManager.S.selectedCrew == "Pilot") {
			DialogueText.SetActive (true);
		}
	}
}