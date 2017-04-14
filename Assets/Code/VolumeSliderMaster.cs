using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliderMaster : MonoBehaviour {
	float masterVolume;
	float sfxVolume;
	float musicVolume;

	public AudioMixer masterMixer;
	public string currentType;

	public void Start()
	{
		masterVolume = 	PlayerPrefs.GetFloat ("volume_" + currentType);
		GetComponent<Slider> ().value = masterVolume;
		masterMixer.SetFloat(currentType, masterVolume);
	}

	public void AdjustVolume (float masterVolume)
	{
		masterMixer.SetFloat (currentType, masterVolume);
		PlayerPrefs.SetFloat ("volume_" + currentType, masterVolume);
	}
}
