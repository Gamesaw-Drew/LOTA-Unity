using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PauseMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxis("StartBtn") != 0)
		{
			pauseGame();
		}
	}
	
	public void pauseGame()
	{
		this.transform.GetChild(1).gameObject.SetActive(true);
		this.transform.GetChild (1).GetComponent<Animator> ().SetTrigger ("Open");
		Time.timeScale = 0.0F;
	}
	
	public void resumeGame()
	{
		this.transform.GetChild(1).gameObject.SetActive(false);
		Time.timeScale = 1.0F;
	}
	
	public void quitGame()
	{
		NetworkManager mgr = GameObject.FindObjectOfType<NetworkManager> ();
		if (mgr) {
			mgr.StopClient ();
		}
		Time.timeScale = 1.0F;
	}
}
