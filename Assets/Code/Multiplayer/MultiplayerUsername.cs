using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerUsername : MonoBehaviour {

	private InputField input;

	// Use this for initialization
	void Start () {
		input = GetComponent<InputField> ();
		input.text = PlayerPrefs.GetString ("username", "");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setName(string name){
		PlayerPrefs.SetString ("username", name);
	}
}
