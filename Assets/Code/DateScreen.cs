/*
 * Imported from PTTSP
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DateScreen : MonoBehaviour {
    public Canvas Screen;
    public GameObject panel;

	// Use this for initialization
	void Start()
    {
        StartCoroutine(ShowDateText());
	}
	
    
    IEnumerator ShowDateText()
	{	
        panel.transform.GetChild(0).GetComponent<Text>().CrossFadeAlpha(0f, 0f, false);
		Screen.enabled = true;
        panel.transform.GetChild(0).GetComponent<Text>().CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(4);
        panel.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        panel.transform.GetChild(0).GetComponent<Text>().CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1);
        Screen.enabled = false;
	}
}
