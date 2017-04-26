using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToCar : MonoBehaviour {

	public Camera camera;
	public GameObject car;
	public GameObject player;
	public Transform carCam;
	public Transform playerCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCar(bool enabled){
		if (enabled) {
			// spawn the car on the player
			car.transform.position = player.transform.position;
			car.transform.rotation = player.transform.rotation;
			car.SetActive (true);
			player.SetActive (false);
			camera.GetComponent<UserCameraControl> ().target = carCam;
		} else {
			car.SetActive (false);
			player.SetActive (true);
			camera.GetComponent<UserCameraControl> ().target = playerCam;
		}
	}
}
