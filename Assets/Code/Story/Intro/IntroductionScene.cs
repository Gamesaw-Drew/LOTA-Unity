using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionScene : MonoBehaviour {

	[SerializeField]
	public GameObject localCharacter;
	[SerializeField]
	public Camera cam;
	private AudioSource voicePlayer;
	public AudioSource bossAudio;
	public AudioSource saulAudio;

	public AudioClip dialog1;
	public AudioClip dialog2;

	public SceneLoader loadScene;

	public GameObject boss_ChatBubble;
	public GameObject saul_ChatBubble;

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
		cam.GetComponent<UserCameraControl> ().enabled = false;
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (0.01f, 8.17f, -20.69f), "easeType", "easeInOutQuad", "loopType", "none", "time", 10, "ignoretimescale", false));
		yield return new WaitForSeconds (10);
		iTween.MoveTo (cam.gameObject, iTween.Hash ("position", new Vector3 (-3.31f, 1.17f, -4.83f), "easeType", "easeInOutQuad", "loopType", "none", "time", .5, "ignoretimescale", false));
		iTween.RotateTo (cam.gameObject, iTween.Hash ("rotation", new Vector3 (0, 30, 0), "easeType", "easeInOutQuad", "loopType", "none", "time", .5, "ignoretimescale", false));
		yield return new WaitForSeconds (1);
		saulAudio.Play ();
		saul_ChatBubble.SetActive (true);
		yield return new WaitForSeconds (4);
		boss_ChatBubble.SetActive (true);
		saul_ChatBubble.SetActive (false);
		bossAudio.Play ();
		yield return new WaitForSeconds (10);
		loadScene.StartLoading ();

	}
}
