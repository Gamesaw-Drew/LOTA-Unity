using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class MultiplayerAiHandler : NetworkBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnStartServer(){
		GetComponent<NavMeshAgent> ().enabled = true;
		GetComponent<UnityStandardAssets.Characters.ThirdPerson.GSNPCWanderAI_Singleplayer> ().enabled = true;
	}
}
