using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {
	[SerializeField]
	public GameObject[] gameobjs;

	// Use this for initialization
	void Start () {
		foreach (GameObject obj in gameobjs) {
			GameObject.Instantiate (obj);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
public class gameobjs
{
	public GameObject[] objects;
}
