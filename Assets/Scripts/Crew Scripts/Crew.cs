using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour {

	public GameObject DialogueText;

	//public string name;
	public int loyalty = 0;
	public bool alive = true;
	public bool culprit = false;

	// Update is called once per frame
	void Update () {
		DeadCheck ();
	}

	public void DeadCheck() {
		if (alive != true) {
			Destroy (gameObject);
		}
	}

	public void HideText() {
		DialogueText.SetActive (false);
	}
}