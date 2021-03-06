﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AccusationManager : MonoBehaviour {

	public static AccusationManager			S;
	public Text 							cluesLeftHeading;
	public Text								cluesLeftText;
	public Button							finalizeAccusationButton;
	public int 								cluesLeftToChoose = 3;
	public string 							selectedCrew;
	public Text 							endText;
	public Button							replay;
	public GameObject 						crewObject; //Testing

	public bool ____________________;

	private float counter = 0;
	private float tempCounter = 0;
	private float maxIndex = 20;
	public GameObject[] crew;
	public float juryVote = 0;

	void Awake ()
	{
		if (S == null)
		{
			S = this;
		}
		else if (S != null)
		{
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start () {

		//finalizeAccusationButton = GameObject.Find ("FinalizeAccusationButton").GetComponent<Button> ();;
		finalizeAccusationButton.gameObject.SetActive (false);
		cluesLeftHeading.gameObject.SetActive (false);
		cluesLeftText.text = cluesLeftToChoose.ToString ();
		cluesLeftText.gameObject.SetActive (false);
		endText.gameObject.SetActive (false);
		replay.gameObject.SetActive (false);

		crew = GameObject.FindGameObjectsWithTag ("Crew");
	}

	// Update is called once per frame
	void Update () {

		RaycastForCrew ();

		cluesLeftText.text = cluesLeftToChoose.ToString ();
	}


	// Use This function to disable all of the Accusation UI elements so that once the player presses
	// the finalizeAccusationButton they will be able to see who they have convinced and who they have not
	public void TurnOffAccusationUIElements()
	{
		// Turn off all of the clueEntry UI elements in the scene
		foreach (GameObject clueEntry in ClueManager._builtCluesMenu)
		{
			clueEntry.gameObject.SetActive (false);
		}

		// Turn off the Clues Left to Accuse heading and Clues Left number text
		cluesLeftText.gameObject.SetActive (false);
		cluesLeftHeading.gameObject.SetActive (false);

		// Turn off the visibility of the FinalizeAccusationButton
		finalizeAccusationButton.gameObject.SetActive (false);

	}

	public void resetSelected() {
		selectedCrew = ""; //Resets which crew was selected
	}

	public void DetermineCrewMembersVerdicts ()
	{
		Debug.Log ("TESTING FUNCTIONALITY");
		//grab all crew members
		//cycle through them
		//do the roll
		//grab the renderer an change the color based on the rol

		foreach (ClueInfo clue in ClueManager._cluesToPresent) {
			counter += clue.rating;//add all presented clue ratings into counter
		}

		Debug.Log ("Default Loyalty at: " + counter);
		maxIndex -= counter;//subtract counter from max index

		foreach (GameObject crewMember in crew) {
			//Checks list for game objects
			if (crewMember != null && crewMember.name != selectedCrew) {
				Renderer rend = crewMember.GetComponent<Renderer> ();
				tempCounter = counter;//temporary counter that resets to default counter

				float roll = Random.Range (0.0f, maxIndex);//get a roll between 0 and new maxIndex
				print ("Random Roll: " + roll);
				tempCounter += roll;//add to counter
				roll = 0;

				//add to every crew member
				Debug.Log ("Loyalty after calculations: " + tempCounter + " for " + crewMember);

				if (tempCounter >= 16) { //basing this on a 20 sided die like DnD
					rend.material.color = Color.green;
					juryVote++;
				} else {
					rend.material.color = Color.red;
					juryVote--;
				}
				//Checks which crew was selected so they don't vote
			} else if (crewMember != null && crewMember.name == selectedCrew) {
				Debug.Log ("You can't vote for your self" + selectedCrew);
			} else {
				Debug.Log ("Nothing happens");
			}
		}
	}

	public void EndScreen() {
		//Checks votes to see if player wins, voting maximum is 3
		if (juryVote >= 1) {
			endText.gameObject.SetActive (true);
		} else {
			endText.text = "YOU LOSE!";
			endText.gameObject.SetActive (true);
		}
		//Replay button still in progress
		//replay.gameObject.SetActive (true);
	}

	void RaycastForCrew() {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Selecting crew");

			Vector3 mousePosition;
			RaycastHit hit;
			Ray ray;

			//Update ray
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			mousePosition = Input.mousePosition;

			//The raycast works but in scene view it points towards canvas
			Debug.DrawRay (transform.position, mousePosition, Color.green);

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				if (hit.collider.tag == "Crew" && selectedCrew == "") {
					// Activate the sprite and corresponding TextBox to be visible when the crew member is clicked on.
					Debug.Log (hit.collider.gameObject.name + " was selected by Raycast");
					crewObject = hit.collider.gameObject;
					//Activate Sprites
					crewObject.GetComponent<Crew>().Sprite.SetActive (true);
					//Activate TextBox
					crewObject.GetComponent<Crew> ().TextBox.SetActive (true);
					//Saves selected crew for dialogue purposes
					selectedCrew = crewObject.name;
				}
			}
		}
	}
}
