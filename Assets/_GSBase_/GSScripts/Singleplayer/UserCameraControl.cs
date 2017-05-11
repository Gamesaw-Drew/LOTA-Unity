using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;
public class UserCameraControl : MonoBehaviour {

	public Transform target;
	public float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float distanceMin = .5f;
	public float distanceMax = 15f;
	public Transform head;
	public Transform headMesh;
	public Transform player;
	public Transform viewmodel;

	private Rigidbody rigidbody;

	public bool isDown = false;

	float x = 0.0f;
	float y = 0.0f;
	float headx = 0.0f;

	public PostProcessingProfile HighProfile;
	public PostProcessingProfile MediumProfile;
	public PostProcessingProfile LowProfile;
	public bool shouldMove = false;

	private Vector3 negDistance;

	public bool isFirstPerson = false;

	public Transform camPoint;

	// Use this for initialization
	void Start () 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		rigidbody = GetComponent<Rigidbody>();

		// Make the rigid body not change rotation
		if (rigidbody != null)
		{
			rigidbody.freezeRotation = true;
		}
		int level = QualitySettings.GetQualityLevel ();

		if (level <= 1) {
			GetComponent<PostProcessingBehaviour> ().profile = LowProfile;
		}
		if (level > 1 && level < 3) {
			GetComponent<PostProcessingBehaviour> ().profile = MediumProfile;
		}
		if (level > 3) {
			GetComponent<PostProcessingBehaviour> ().profile = HighProfile;
		}
	}

	void LateUpdate() 
	{
		if (target) 
		{

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin - .25f, distanceMax);

			if (distance < distanceMin) {
				negDistance = new Vector3(0f, 0.25f, .2f);
				//headMesh.GetComponent<SkinnedMeshRenderer> ().enabled = false;
				shouldMove = true;
				isDown = true;
				isFirstPerson = true;
				if (player.gameObject.activeInHierarchy) {
					target = head;
				}
			} else {
				negDistance = new Vector3(0.5f, 0.0f, -distance);
				//headMesh.GetComponent<SkinnedMeshRenderer> ().enabled = true;
				if (Input.GetAxis ("Fire2") != 0) {
					shouldMove = true;
					isDown = true;
				} else {
					shouldMove = false;
					isDown = false;
				}
				if (player.gameObject.activeInHierarchy) {
					target = camPoint;
				}
				isFirstPerson = false;
			}
			if(shouldMove){

				if (Input.GetAxis ("JoyX") != 0 && Input.GetAxis ("JoyY") != 0) {
					x += Input.GetAxis ("JoyX") * xSpeed * distance * 0.02f;
					y -= Input.GetAxis ("JoyY") * ySpeed * 0.02f;
				} else {
					x += Input.GetAxis ("Mouse X") * xSpeed * distance * 0.02f;
					y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
				}
				y = ClampAngle (y, yMinLimit, yMaxLimit);
				Quaternion playerRot = Quaternion.Euler (0, x, 0);
				player.rotation = playerRot;
				isDown = true;

			} else if (Input.GetAxis ("JoyX") != 0 && Input.GetAxis ("JoyY") != 0) {
				x += Input.GetAxis ("JoyX") * xSpeed * distance * 0.02f;
				y -= Input.GetAxis ("JoyY") * ySpeed * 0.02f;

				y = ClampAngle (y, yMinLimit, yMaxLimit);
			}

			else {
				isDown = false;
				shouldMove = false;
			}
			Quaternion rotation = Quaternion.Euler(y, x, 0);


			/*RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) 
			{
				distance -=  hit.distance;
			}
			*/

			Vector3 position = rotation * negDistance + target.position;

			transform.rotation = rotation;
			transform.position = position;
			/*
			if (Input.GetMouseButton (1)) {
				headx = ClampAngle(transform.rotation.eulerAngles.y, -20.0f, 20.0f);
			
				Quaternion headrotation = Quaternion.Euler(transform.rotation.eulerAngles.y, headx, 0);
				head.localRotation = headrotation;
			}*/
			if (isFirstPerson) {
				head.rotation = rotation;
			} else {
			}

		}			

	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}