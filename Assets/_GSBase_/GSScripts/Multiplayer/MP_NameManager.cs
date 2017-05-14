using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using TMPro;
using UnityEngine.UI;

public class MP_NameManager : NetworkBehaviour {

	[SyncVar(hook = "OnNameChange")] private string localUsername;
	[SyncVar(hook = "OnBlipColorChange")] private Color blipColor;
	public TMPro.TextMeshPro text;
	public TMPro.TextMeshPro minimapText;
	public SpriteRenderer minimapBlip;
	public TMPro.TMP_InputField chatInput;
	public Text chatTextBox;
	[SyncVar(hook = "OnChatMessage")] public string chatMessage; // store it to detect if it changes

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public override void OnStartLocalPlayer(){
		localUsername = PlayerPrefs.GetString ("username", "PlayerName");
		Cmd_SendUsername (localUsername);
		blipColor = new Color (Random.Range (0.5f, 1.0f), Random.Range (0.5f, 1.0f), Random.Range (0.5f, 1.0f));
		Cmd_SendColor (blipColor);
		chatTextBox = GameObject.FindGameObjectWithTag ("TextBox").GetComponent<Text> ();
		chatInput = GameObject.FindGameObjectWithTag ("ChatInput").GetComponent<TMPro.TMP_InputField> ();
		GameObject.FindGameObjectWithTag ("ChatInput").GetComponent<ChatManager> ().localPlayer = this;
	}

	[Command]
	void Cmd_SendUsername(string username){
		localUsername = username;
	}

	[Command]
	void Cmd_SendColor(Color color){
		blipColor = color;
	}

	public override void OnStartClient(){
		OnNameChange (localUsername);
		OnBlipColorChange (blipColor);
		OnChatMessage (chatMessage);
	}

	void OnNameChange(string username)
	{
		text.text = username;
		minimapText.text = username;
	}
	void OnBlipColorChange(Color color){
		minimapBlip.color = color;
	}

	public void SendChat(string message){
		Cmd_SendMessage (message);
	}

	[Command]
	void Cmd_SendMessage(string message){
		chatMessage = "\n"+localUsername+": "+ message;
	}

	void OnChatMessage(string message){
		GameObject.FindGameObjectWithTag ("TextBox").GetComponent<Text> ().text += message;
		chatMessage = "";
	}

}
