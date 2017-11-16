using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuryManager : MonoBehaviour {

	//This was created for tracking who the player selected
	//I plan to make this into the main Jury script
	public static JuryManager jurySingleton;
	public string selectedCrew;

	void Awake() {
		jurySingleton = this;
	}

	public void resetSelected() {
		selectedCrew = "";
	}
}
