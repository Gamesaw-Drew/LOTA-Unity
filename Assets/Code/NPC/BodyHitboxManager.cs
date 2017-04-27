using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHitboxManager : MonoBehaviour {

	public hitboxType type;
	public HealthSystem hpMgr;
	private float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{

		if (col.tag == "damage") {
			if (type == hitboxType.head) {
				damage = 20.0f;
			}
			else if(type == hitboxType.torso){
				damage = 10.0f;
			}
			else if(type == hitboxType.legs){
				damage = 5.0f;
			}
			hpMgr.damage (damage);
		}
	}
}
public enum hitboxType {
head, torso, legs
}