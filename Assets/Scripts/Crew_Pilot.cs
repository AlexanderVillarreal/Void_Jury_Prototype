﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Pilot : Crew {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DeadCheck ();
	}

	void OnMouseDown() {
		Judgement ();
	}
}