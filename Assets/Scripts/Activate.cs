using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {

	public Collect coll;

	public GameObject button;
	public int evidenceTotal = 0;

	//On start turn off button
	void Start() {
		button.SetActive (false);
	}

	void Update() {
		//Checks evidence to see if we have enough to turn button on
		if (evidenceTotal >= 5) {
			button.SetActive (true);
		}

		//Updates total evidence with the evidence integer from Collect Class
		evidenceTotal = coll.evidence;
	}
}
