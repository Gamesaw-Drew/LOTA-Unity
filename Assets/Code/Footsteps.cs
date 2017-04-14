/*
this is mainly just a little filler for an actual decent footstep sound thing
only works when walking forward 
*/

using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Footsteps : MonoBehaviour {

    private float footstepTimerDelay = 0.45f;
    private float footstepTimer;
	private AudioClip stepSound;
	public AudioClip WoodClip;
	public AudioClip SandClip;
	public bool isSprinting;

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnCollisionStay(Collision col)
	{
		string floortype = col.gameObject.tag;
		if (floortype == "Wood") {
			stepSound = WoodClip;
			GetComponent<AudioSource> ().clip = stepSound;
			Debug.Log ("WOOD XD");
		}
		if (floortype == "Sand") {
			stepSound = SandClip;
			GetComponent<AudioSource> ().clip = stepSound;
			Debug.Log ("SAND XD");
		}

	}
	void OnCollisionExit(Collision col)
		{
			stepSound = null;
		}
	// Update is called once per frame
	void FixedUpdate ()
    {
		isSprinting = GetComponent<GSCharacterUserInput_Singleplayer> ().isSprinting;

		if (isSprinting) {
			footstepTimerDelay = 0.225f;
		}
		else {
			footstepTimerDelay = 0.45f;
		}

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float j = CrossPlatformInputManager.GetAxis("Jump");
        footstepTimer = footstepTimer + Time.deltaTime;
        if (footstepTimer >= footstepTimerDelay)
        {
            footstepTimer = 0f;
			if (v != 0 || h != 0)
            {
				GetComponent<AudioSource>().clip = stepSound;
                GetComponent<AudioSource>().Play();
            }
			if (v == 0 && h == 0)
            {
                GetComponent<AudioSource>().Stop();
            }
        }
	}
}
