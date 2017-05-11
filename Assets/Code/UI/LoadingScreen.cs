using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
    
    Canvas Screen;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this); 
        Screen = this.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Application.isLoadingLevel)
        {
            Screen.enabled = true;
        }
        else
        {
            Screen.enabled = false;
        }
	
	}
    
}
