using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using TMPro;

public class MP_NameManager : NetworkBehaviour {

	[SyncVar(hook = "OnNameChange")] private string localUsername;
	public TMPro.TextMeshPro text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public override void OnStartLocalPlayer(){
		localUsername = PlayerPrefs.GetString ("username", "PlayerName");
		Cmd_SendUsername (localUsername);
	}

	[Command]
	void Cmd_SendUsername(string username){
		localUsername = username;

	}

	public override void OnStartClient(){
		OnNameChange (localUsername);
	}

	void OnNameChange(string username)
	{
		text.text = username;
	}

}
