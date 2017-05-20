using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPConnectScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnScreen(){
		GameObject.Instantiate (Resources.Load ("Network"));
		GameObject.Instantiate (Resources.Load ("MPConnect"));
	}
}
