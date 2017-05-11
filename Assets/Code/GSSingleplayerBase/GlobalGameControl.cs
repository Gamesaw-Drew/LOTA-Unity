using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameControl : MonoBehaviour {

	public static GlobalGameControl Instance;

	public int LastMissionID = 0;

	void Awake ()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	public void SaveData()
	{
		
	}

	public void setLastMission(int id)
	{
		LastMissionID = id;
	}

	public int getLastMission()
	{
		return LastMissionID;
	}
}
