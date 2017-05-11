using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AMD_HQ_FIND_MACHINE : MonoBehaviour {
    
	public GameObject startSkype;

	[SerializeField]
	public GameObject localCharacter;
    [SerializeField]
	public Camera cam;
	[SerializeField]
	public Image tip
;

	// Use this for initialization
	void Start () {
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
		localCharacter.GetComponent<Animator> ().SetFloat ("Speed", 0);
		tip.gameObject.GetComponent<Animator>().Play("Close");
		localCharacter.GetComponent<Animator> ().SetTrigger ("DoSceneOne");
		cam.GetComponent<UserCameraControl> ().enabled = false;
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (932.4f, 0.17f, 14.3f), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (-10, 20, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = false;
		localCharacter.GetComponent<Footsteps> ().enabled = false;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;

		iTween.MoveTo (localCharacter, iTween.Hash ("position", new Vector3 (931.4f, -1.163f, 14.3f), "easeType", "easeInOutQuad", "loopType", "none", "time", 1, "ignoretimescale", false));
		iTween.RotateTo (localCharacter, iTween.Hash ("rotation", new Vector3 (0, 48, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 1, "ignoretimescale", false));

		yield return new WaitForSeconds (3);
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (932.4f, 3.17f, 14.9f), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (0, 25, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		yield return new WaitForSeconds (4);
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (931.4f, 2.17f, 13.6f), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (-2, 20, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		yield return new WaitForSeconds (6);
		cam.GetComponent<UserCameraControl> ().enabled = true;
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = true;
		localCharacter.GetComponent<Footsteps> ().enabled = true;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = true;
		tip.gameObject.GetComponent<Animator> ().Play ("Open");
		tip.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "Go back to Chris's room and join the skype call";
		localCharacter.GetComponent<Animator> ().ResetTrigger ("DoSceneOne");

;
		startSkype.SetActive (true);

		GlobalGameControl.Instance.setLastMission (1);

	}
}
