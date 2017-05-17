﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseExplode : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Explode()
	{
		Vector3 pos = new Vector3 (-6, 2, -0);
		foreach(BuildingBlock block in GetComponentsInChildren<BuildingBlock> ())
		{
			block.Explode ();
		}
	}
}
