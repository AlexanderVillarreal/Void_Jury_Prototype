using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuryTest : MonoBehaviour {

	public void Judgement() {
		Renderer rend = GetComponent<Renderer> ();

		float roll = Random.Range (0.0f, 10.0f);

		print ("They rolled a " + roll);

		if (roll <= 6) {
			rend.material.color = Color.green;
		} else {
			rend.material.color = Color.red;
		}
	}

	void OnMouseDown() {
		Judgement ();
	}
}
