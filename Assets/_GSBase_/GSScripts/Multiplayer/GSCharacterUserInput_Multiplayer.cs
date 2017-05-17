using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class GSCharacterUserInput_Multiplayer : NetworkBehaviour {
	
	public float RunSpeed = 10.0f;
	public float WalkSpeed = 7.0f;
	public float JumpForce = 400.0f;
	public float JumpDelay = 1.0f;

	private float jumpingTime;
	private Rigidbody body;
	public bool isSprinting;
	public Camera camera;

	// Use this for initialization
	void Start () {
		this.body = GetComponent<Rigidbody>();
		this.camera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
	}
	
	void FixedUpdate ()
	{
		if (isLocalPlayer) {
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");
			bool j = CrossPlatformInputManager.GetButton("Jump");
			float sprint = CrossPlatformInputManager.GetAxis("Sprint");

			if (v != 0 || h != 0){
				if (sprint != 0.0f) {
					RunSpeed = 10.0f;
					isSprinting = true;
					GetComponent<Animator> ().SetFloat ("Forward", Mathf.Clamp(GetComponent<Animator>().GetFloat("Forward"), -1.0f, 1.0f) * 2.0f, 0.2f, Time.deltaTime);
				}
				else {
					RunSpeed = 5.0f;
					isSprinting = false;
					GetComponent<Animator> ().SetFloat ("Forward", Mathf.Clamp(GetComponent<Animator>().GetFloat("Forward"), -1.0f, 0.2f) * 1.0f, 0.2f, Time.deltaTime);
				}
			}


			if (v > 0)
			{
				transform.Translate(Vector3.forward * v * this.RunSpeed*Time.deltaTime);
			}

			if (v < 0)
			{
				transform.Translate(Vector3.back * -1 * v * this.WalkSpeed*Time.deltaTime);
			}
			if (camera.GetComponent<UserCameraControlMP>().isDown) {
				if (!GetComponent<Animator> ().GetBool ("IsAiming")) {
					GetComponent<Animator> ().SetBool ("IsAiming", true);
					Debug.Log ("ISAIM");
				}
				if (h < 0) {
					transform.Translate (Vector3.left * -1 * h * this.WalkSpeed * Time.deltaTime);
					GetComponent<Animator> ().SetFloat ("Strafe", Mathf.Clamp(GetComponent<Animator>().GetFloat("Strafe"), -1.0f, 2.0f) * -1.0f, 0.2f, Time.deltaTime);
				}

				if (h > 0) {
					transform.Translate (Vector3.right * h * this.WalkSpeed * Time.deltaTime);
					GetComponent<Animator> ().SetFloat ("Strafe", Mathf.Clamp (GetComponent<Animator> ().GetFloat ("Strafe"), -1.0f, 2.0f) * 1.0f, 0.2f, Time.deltaTime);

				}

			} else {
				if (GetComponent<Animator> ().GetBool ("IsAiming")) {
					GetComponent<Animator> ().SetBool ("IsAiming", false);
					Debug.Log ("NOAIM!");
				}
				if (h < 0) {
					transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 5 * -1 * h, transform.eulerAngles.z);
				}

				if (h > 0) {
					transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 5 * h, transform.eulerAngles.z);
				}
			}
			if (this.jumpingTime <= 0.0f)
			{
				if (this.body != null)
				{
					if (j)
					{
						this.jumpingTime = this.JumpDelay;

						Vector2 jump = Vector2.up*this.JumpForce;

						if (this.body != null)
						{
							this.body.AddForce(jump);
						}
					}
				}
			}
			else
			{
				this.jumpingTime -= Time.deltaTime;
			}
		}
	}
}