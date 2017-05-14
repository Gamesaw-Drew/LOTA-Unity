using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateMultiplayerCharacter : NetworkBehaviour {
	public Transform headBone;
	public Transform headMesh;
	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			GameObject.FindWithTag ("MainCamera").GetComponent<UserCameraControlMP> ().target = gameObject.transform.GetChild(0);
			GameObject.FindWithTag ("MainCamera").GetComponent<UserCameraControlMP> ().player = gameObject.transform;
			GameObject.FindWithTag ("MainCamera").GetComponent<UserCameraControlMP> ().head = headBone;
			GameObject.FindWithTag ("MainCamera").GetComponent<UserCameraControlMP> ().headMesh = headMesh;
			GameObject.FindWithTag ("MinimapCam").GetComponent<HorizontalFollow> ().target = transform;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
