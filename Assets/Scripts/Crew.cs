using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour {

	public string name;
	public int loyalty = 0;
	public bool alive = true;
	public bool culprit = false;
	public string sprite;

	public void Judgement() {
		//For the sake of testing this will be used to change color
		Renderer rend = GetComponent<Renderer> ();

		float roll = Random.Range (0.0f, 10.0f);

		print ("They rolled a " + roll);

		//Numer should be an int variable that changes with evidence presented
		if (roll <= 6) {
			rend.material.color = Color.green;
		} else {
			rend.material.color = Color.red;
		}
	}
}
