using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HealthSystem : MonoBehaviour {

	public float maxHealth = 100f;
	public Slider healthSlider;
	// Use this for initialization
	void Start () {
		// Set the slider and such to the max health, also heal it all the way
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
	}
	
	void Update () {
		
	}

	public void damage(float damageAmount){
		healthSlider.value = (healthSlider.value - damageAmount);
		if (healthSlider.value <= 0) {
			GetComponent<UnityStandardAssets.Characters.ThirdPerson.GSNPCWanderAI_Singleplayer> ().enabled = false;
			GetComponent<NavMeshAgent> ().enabled = false;
			StartCoroutine ("kill");
		}
	}

	IEnumerator kill(){
		yield return new WaitForSeconds (1);
		Destroy(gameObject);
	}
}
