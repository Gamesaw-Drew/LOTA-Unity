using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxPopup : MonoBehaviour {

	public MaterialUI.DialogBoxConfig dialog;
	// Use this for initialization
	void Start () {
		// This is used to automatically popup a dialog when a scene is loaded
		dialog.Open();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
