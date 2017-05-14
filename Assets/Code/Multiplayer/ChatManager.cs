using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour {
	public MP_NameManager localPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendText(string msg){
		localPlayer.SendChat (msg);
		GetComponent<TMPro.TMP_InputField> ().text = "";
	}
}
