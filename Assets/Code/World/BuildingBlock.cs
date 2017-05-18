﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Explode(){
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(Random.Range(0.0f, 5.0f), 5f, Random.Range(0.0f, 5.0f))); 
	}
}