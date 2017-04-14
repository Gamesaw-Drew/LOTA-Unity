using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA;

public class anselToggle : MonoBehaviour {

	// Use this for initialization
	public Ansel baseAnsel;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.F3)){
			
		Ansel.SessionData session = new Ansel.SessionData();
		session.isAnselAllowed = true;
		session.isFovChangeAllowed = true;
		session.isHighresAllowed = true;
		session.isPauseAllowed = true;
		session.isRotationAllowed = true;
		session.isTranslationAllowed = true;
		session.is360StereoAllowed = false;
		session.is360MonoAllowed = false;
		baseAnsel.ConfigureSession(session);
		}
		if(Input.GetKeyDown(KeyCode.F4)){

			Ansel.SessionData session = new Ansel.SessionData();
			session.isAnselAllowed = false;
			session.isFovChangeAllowed = true;
			session.isHighresAllowed = true;
			session.isPauseAllowed = true;
			session.isRotationAllowed = true;
			session.isTranslationAllowed = true;
			session.is360StereoAllowed = false;
			session.is360MonoAllowed = false;
			baseAnsel.ConfigureSession(session);
		}
	}
}
