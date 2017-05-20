using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiplayerConnectScreenUI : MonoBehaviour {

	public NetworkManager manager;
	public InputField ipField;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Network(Clone)").GetComponent<NetworkManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startHost(){
		manager.StartHost ();
	}

	public void startConnect(){
		if (ipField.text != "") {
			manager.networkAddress = ipField.text;
			manager.StartClient ();
		}
	}

	public void startServer(){
		manager.StartServer ();
	}

	public void Kill(){
		DestroyImmediate (this.gameObject);
	}
}
