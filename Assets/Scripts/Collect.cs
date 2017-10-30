using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	public int evidence = 0;

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			OnMouseDown ();
		}
	}
	public void CollectObject () {
		if (GameObject.FindWithTag ("Evidence")) {
			Destroy (GameObject.FindWithTag("Evidence"));
			print ("+1 Evidence");
			evidence++;
		}
	}
		
	public void OnMouseDown() {
		CollectObject ();
		print (evidence);
	}
}