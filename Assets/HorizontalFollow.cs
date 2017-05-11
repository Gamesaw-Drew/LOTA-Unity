using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalFollow : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void LateUpdate()
	{
		transform.position = new Vector3(target.position.x, -4.44f, target.position.z);
	}
}
