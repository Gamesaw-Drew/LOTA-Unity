﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Escape))
		{
			pauseGame();
		}
	}
	
	public void pauseGame()
	{
		this.transform.GetChild(1).gameObject.SetActive(true);
		Time.timeScale = 0.0F;
	}
	
	public void resumeGame()
	{
		this.transform.GetChild(1).gameObject.SetActive(false);
		Time.timeScale = 1.0F;
	}
	
	public void quitGame()
	{
		Time.timeScale = 1.0F;
	}
}
