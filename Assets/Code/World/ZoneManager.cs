using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour {
	public AudioClip exteriorMusic;
	private bool isInZone = false;
	private GameObject zoneUI;
	public string zoneName;
	// Use this for initialization
	void Start () {
		zoneUI = GameObject.Find ("ZonePopup");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			if (!isInZone) {
				transform.parent.GetComponent<AudioSource> ().clip = exteriorMusic;
				transform.parent.GetComponent<AudioSource> ().Play ();
				isInZone = true;
				zoneUI.transform.GetChild (0).GetChild (0).GetComponent<TMPro.TextMeshProUGUI> ().text = zoneName;
				zoneUI.GetComponent<Animator> ().SetTrigger ("Zone");
			}
		}
	}

	public void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			if (isInZone) {
				transform.parent.GetComponent<AudioSource> ().Stop ();
				isInZone = false;
			}
		}
	}
}
