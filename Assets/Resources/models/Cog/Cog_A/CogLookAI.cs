using UnityEngine;
using System.Collections;

	public class CogLookAI : MonoBehaviour
	{
		public float speed = 5;
		public float directionChangeInterval = 1;
		public float maxHeadingChange = 30;
	 
		float heading;
		Vector3 targetRotation;
	 
		void Awake ()
		{ 
			heading = Random.Range(0, 360);
			transform.eulerAngles = new Vector3(0, heading, 0);
	 
			StartCoroutine(NewHeading());
		}
	 
		void Update ()
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		}

		IEnumerator NewHeading ()
		{
			while (true) {
				NewHeadingRoutine();
				yield return new WaitForSeconds(directionChangeInterval);
			}
		}

		void NewHeadingRoutine ()
		{
			var min = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
			var max  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
			heading = Random.Range(min, max);
			targetRotation = new Vector3(0, heading, 0);
		}
	}
