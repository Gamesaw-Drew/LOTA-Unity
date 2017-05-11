using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCull : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera camera = GetComponent<Camera>();
		float[] distances = new float[32];
		distances [8] = 110;
		distances [9] = 140;
		camera.layerCullDistances = distances;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
