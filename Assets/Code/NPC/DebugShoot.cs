using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugShoot : MonoBehaviour {
    public Rigidbody projectile;
	public Camera mainCam;
	public Image crosshair;
    
    void Update() {
		if (Input.GetButton ("Fire2")) {
			crosshair.enabled = true;
		} else {
			crosshair.enabled = false;
		}

        if (Input.GetButtonDown("Fire1")) {
			if (Input.GetButton ("Fire2")) {
				Rigidbody clone;
				clone = Instantiate (projectile, transform.position, transform.rotation) as Rigidbody;
				clone.velocity = mainCam.transform.TransformDirection (Vector3.forward * 100);        
				Destroy (clone.gameObject, 10.0f); // Destroys the bullet after 2 seconds
			}
        }  
    }
}
 