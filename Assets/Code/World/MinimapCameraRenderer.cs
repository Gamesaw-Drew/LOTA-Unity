using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraRenderer : MonoBehaviour {

     private float FPS = 10f;
     private Camera renderCam;
     // Use this for initialization
     void Start () {
		renderCam = GetComponent<Camera> ();
         InvokeRepeating ("Render", 0f, 1f / FPS);
     }
     void OnDestroy(){
		CancelInvoke ();
     }
     void Render(){
         renderCam.enabled = true;
     }
     void OnPostRender(){
         renderCam.enabled = false;
     }
}
