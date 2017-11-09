using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwake : MonoBehaviour {

	//All of this is attached to Camera
	public Crew_FirstMate _FirstMate;
	public Crew_Pilot _Pilot;
	public Crew_Cook _Cook;
	public Crew_Doctor _Doctor;
	public Crew_Engineer _Engineer;

	public int crewCulprit;
	public int crewAlive;

	void Awake() {
		//Rolls for starting victim
		crewAlive = Random.Range (0, 2);
		//Rolls for culprit
		crewCulprit = Random.Range (0, 2);

		//Sets who dies at the start
		if (crewAlive == 1) {
			_Cook.alive = false;
			Debug.Log ("Cook is dead");
		} else {
			_Engineer.alive = false;
			Debug.Log ("Engineer is dead");
		}

		//Sets who is the culprit
		if (crewCulprit == 1) {
			_FirstMate.culprit = true;
			Debug.Log ("The culprit is the FirstMate");
		} else {
			_Pilot.culprit = true;
			Debug.Log ("The culprit is the Pilot");
		}
	}
}