using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CogHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision col)
	{
		//if (col.gameObject.tag == "CogDamager")
		//{
			StartCoroutine ("takeDamage");
		//}
	}

	IEnumerator takeDamage()
	{
		GetComponent<Animator> ().SetTrigger ("TakeDamage");
		GetComponent<NavMeshAgent> ().enabled = false;
		yield return new WaitForSeconds (1);
		GetComponent<NavMeshAgent> ().enabled = true;
	}
}
