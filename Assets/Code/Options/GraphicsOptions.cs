using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class GraphicsOptions : MonoBehaviour {
    
	public PostProcessingProfile HighProfile;
	public PostProcessingProfile MediumProfile;
	public PostProcessingProfile LowProfile;
	public Camera camera;

    public void Start()
    {
		int level = PlayerPrefs.GetInt ("graphics_level");
		SetGraphics (level);
		GetComponent<MaterialUI.SelectionBoxConfig> ().currentSelection = level;
		GetComponent<MaterialUI.SelectionBoxConfig>().selectedText.text = GetComponent<MaterialUI.SelectionBoxConfig>().listItems[level];
		GetComponent<MaterialUI.SelectionBoxConfig> ().ItemPicked += SetGraphics;
    }

    public void SetGraphics(int level)
	{
		QualitySettings.SetQualityLevel (level, true);
		PlayerPrefs.SetInt ("graphics_level", level);

		if (level <= 1) {
			camera.GetComponent<PostProcessingBehaviour> ().profile = LowProfile;
		}
		if (level > 1 && level < 3) {
			camera.GetComponent<PostProcessingBehaviour> ().profile = MediumProfile;
		}
		if (level > 3) {
			camera.GetComponent<PostProcessingBehaviour> ().profile = HighProfile;
		}
	}

}