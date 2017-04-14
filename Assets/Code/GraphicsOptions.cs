using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsOptions : MonoBehaviour {
    
    public void Start()
    {
		int level = PlayerPrefs.GetInt ("graphics_level");
		SetGraphics (level);
		GetComponent<Dropdown> ().value = level;
    }

    public void SetGraphics(int level)
    {
        QualitySettings.SetQualityLevel(level, true);
		PlayerPrefs.SetInt ("graphics_level", level);
    }
}