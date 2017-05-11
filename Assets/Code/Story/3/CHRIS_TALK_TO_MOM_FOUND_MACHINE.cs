using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHRIS_TALK_TO_MOM_FOUND_MACHINE : MonoBehaviour {

	[SerializeField]public GameObject localCharacter;
	[SerializeField]public Camera cam;
	[SerializeField]public Image tip;
	public GameObject revolver;
    public GameObject chrisMom;
	private AudioSource voicePlayer;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;

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
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = false;
		localCharacter.GetComponent<Animator> ().SetFloat ("Speed", 0);
		localCharacter.GetComponent<Animator> ().SetInteger ("DoSceneAnimation", 2);
		cam.GetComponent<UserCameraControl> ().enabled = false;
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = false;

		localCharacter.GetComponent<Footsteps> ().enabled = false;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (13.4f, 1.4f, 6.6f), "easeType", "easeInOutQuad", "loopType", "none", "time", .5f, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (4, 260, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", .5f, "ignoretimescale", false));

		iTween.MoveTo (localCharacter, iTween.Hash ("position", new Vector3 (9.012f, -1.08f, 3.323f), "easeType", "easeInOutQuad", "loopType", "none", "time", .1f, "ignoretimescale", false));
		iTween.RotateTo (localCharacter, iTween.Hash ("rotation", new Vector3 (0, 10, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", .1f, "ignoretimescale", false));
		yield return new WaitForSeconds (3);
		voicePlayer.clip = clip1;
		voicePlayer.Play ();

		yield return new WaitForSeconds (7);
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (8.8f, 1.6f, 6.7f), "easeType", "easeInOutQuad", "loopType", "none", "time", 1f, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (16, 176, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 1f, "ignoretimescale", false));
		yield return new WaitForSeconds (2f);
		revolver.SetActive (true);
		yield return new WaitForSeconds (5);
		cam.GetComponent<UserCameraControl> ().enabled = true;
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = true;
		localCharacter.GetComponent<Footsteps> ().enabled = true;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = true;
		tip.gameObject.GetComponent<Animator> ().Play ("Open");
		tip.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "{TODO}";
		localCharacter.GetComponent<Animator> ().SetInteger ("DoSceneAnimation", 0);
		revolver.SetActive (false);
		GlobalGameControl.Instance.setLastMission (3);
	}
}
