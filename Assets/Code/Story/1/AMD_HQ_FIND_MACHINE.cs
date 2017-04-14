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
		tip.gameObject.GetComponent<Animator>().Play("Close");
		cam.GetComponent<UnityStandardAssets.Utility.FollowTarget> ().enabled = false;
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (146f, 1.1f, -36f), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (-10, 116, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = false;
		localCharacter.GetComponent<Footsteps> ().enabled = false;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;
		localCharacter.GetComponent<Animator> ().SetFloat ("Speed", 0);
		iTween.MoveTo (localCharacter, iTween.Hash ("position", new Vector3 (148.66f, -1.04f, -37.6f), "easeType", "easeInOutQuad", "loopType", "none", "time", 1, "ignoretimescale", false));
		yield return new WaitForSeconds (3);
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (147f, 4f, -39f), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (6, 120, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		yield return new WaitForSeconds (4);
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (149f, 1.5f, -37.5f), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (5, 116, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", 3, "ignoretimescale", false));
		yield return new WaitForSeconds (6);
		cam.GetComponent<UnityStandardAssets.Utility.FollowTarget> ().enabled = true;
		localCharacter.GetComponent<GSCharacterUserInput_Singleplayer> ().enabled = true;
		localCharacter.GetComponent<Footsteps> ().enabled = true;
		localCharacter.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = true;
		tip.gameObject.GetComponent<Animator> ().Play ("Open");
		tip.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "Go back to Chris's room and join the skype call";

;
		startSkype.SetActive (true);
	}
}
