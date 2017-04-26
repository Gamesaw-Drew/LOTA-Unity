using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKYPE_CALL_FOUND_MACHINE : MonoBehaviour {

	[SerializeField]public GameObject localCharacter;
	[SerializeField]public Camera cam;
	[SerializeField]public Image tip;
	private AudioSource voicePlayer;
	public AudioClip tellDrewJason;
	public AudioClip drewAmdBad;
	public AudioClip jasonAmdBad;
	public AudioClip chrisAmdGood;
	public GameObject start_chris_mom;

	// Use this for initialization
	void Start () {
		voicePlayer = GetComponent<AudioSource> ();
		StartCoroutine (startCutscene ());
	}

	// Update is called once per frame
	void Update () {

	}

	public void beginCutscene()
	{

	}

	IEnumerator startCutscene()
	{
		tip.gameObject.GetComponent<Animator>().Play("Close");
		cam.GetComponent<UserCameraControl> ().enabled = false;
		localCharacter.GetComponent<Animator> ().SetTrigger ("DoSceneOne");
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (-5.975f, 0.619f, 4.472f), "easeInOutQuad", "easeInOut", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (21, 285, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = false;
		localCharacter.GetComponent<Footsteps> ().enabled = false;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;
		localCharacter.GetComponent<Animator> ().SetFloat ("Speed", 0);
		iTween.MoveTo (localCharacter, iTween.Hash ("position", new Vector3 (-3f, -1.02f, 4f), "easeType", "easeInOutQuad", "loopType", "none", "time", 1, "ignoretimescale", false));
		yield return new WaitForSeconds (2);
		voicePlayer.clip = tellDrewJason;
		voicePlayer.Play ();
		yield return new WaitForSeconds (6);
		voicePlayer.clip = drewAmdBad;
		voicePlayer.Play ();
		yield return new WaitForSeconds (4);
		voicePlayer.clip = jasonAmdBad;
		voicePlayer.Play ();
		yield return new WaitForSeconds (5);
		voicePlayer.clip = chrisAmdGood;
		voicePlayer.Play ();
		yield return new WaitForSeconds (8);
		cam.GetComponent<UserCameraControl> ().enabled = true;
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = true;
		localCharacter.GetComponent<Footsteps> ().enabled = true;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = true;
		tip.gameObject.GetComponent<Animator> ().Play ("Open");
		tip.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "Go talk to Chris's mom";
		start_chris_mom.SetActive (true);
	}
}
