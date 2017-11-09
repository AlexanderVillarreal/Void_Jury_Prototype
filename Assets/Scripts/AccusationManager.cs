using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AccusationManager : MonoBehaviour {

	public static AccusationManager			S;
	public Text 							cluesLeftHeading;
	public Text								cluesLeftText;
	public Button							finalizeAccusationButton;
	public int 								cluesLeftToChoose = 3;

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

	}

	// Update is called once per frame
	void Update () {

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


	public void DetermineCrewMembersVerdicts ()
	{
		print ("TESTING FUNCTIONALITY");
	}
}
