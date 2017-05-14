using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPMinimapStart : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void TargetPlayer(){
		GetComponent<HorizontalFollow> ().target = target;
	}
}
