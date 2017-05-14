using System.Collections;
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
		foreach(Rigidbody block in GetComponentsInChildren<Rigidbody> ())
		{
			block.isKinematic = false;
			block.velocity = transform.TransformDirection(new Vector3(Random.Range(0.0f, 5.0f), 5f, Random.Range(0.0f, 5.0f))); 
		}
	}
}
