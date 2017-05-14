using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalFollow : MonoBehaviour {
	public Transform target;

	public float height = 130f;
	public bool rotate = false;
	public bool heightFromTarget = false;

	public float xrot = 90f;
	public float heightOffset = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void LateUpdate()
	{
		if (heightFromTarget) {
			height = target.position.y + heightOffset;
		}
		transform.position = new Vector3(target.position.x, height, target.position.z);
		if (rotate) {
			transform.rotation = Quaternion.Euler (xrot, 0, target.eulerAngles.y);
		}
	}
}
