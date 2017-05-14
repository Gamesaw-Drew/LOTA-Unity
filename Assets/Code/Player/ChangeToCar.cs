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
			car.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl> ().inputEnabled = true;
			player.SetActive (false);
			#if PLATFORM_ANDROID
			camera.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().target = carCam;
			#else
			camera.GetComponent<UserCameraControl> ().target = carCam;
			#endif
		} else {
			// Move the player to the car location
			player.transform.position = car.transform.position;
			car.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl> ().inputEnabled = false;
			player.SetActive (true);
			#if PLATFORM_ANDROID
			camera.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().target = playerCam;
			#else
			camera.GetComponent<UserCameraControl> ().target = playerCam;
			#endif
		}
	}
}
