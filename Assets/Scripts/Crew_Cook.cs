using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Cook : Crew {

	//Canvas GameObjects for chatbox
	public GameObject TextBox;
	public GameObject Sprite;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		DeadCheck ();
	}

	/*void OnMouseDown() {
		Judgement ();
	}*/

	void OnMouseDown()
	{
		Sprite.SetActive (true);
		TextBox.SetActive (true);
	}
}
