using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour {

	public GameObject missionObject;
	public int expectedMissionID;

	// Use this for initialization
	void Start () {
		if (expectedMissionID == GlobalGameControl.Instance.getLastMission () + 1) {
			missionObject.SetActive (true);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
