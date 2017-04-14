using UnityEngine;
using System.Collections;

	[RequireComponent(typeof(Animator))]

	public class CogMovement : MonoBehaviour
	{
		Animator m_Animator;
		[SerializeField]
		public bool enableMove;
		public bool isAttackThrowing;
		public float WalkSpeed = 10f;
		// Use this for initialization
		void Start ()
		{
			m_Animator = GetComponent<Animator>();
		}
		
		// Update is called once per frame
		void Update ()
		{		
			if(isAttackThrowing)
			{
				m_Animator.SetBool("isAttackThrowing", true);
			}
			else
			{
				m_Animator.SetBool("isAttackThrowing", false);
			}
			if(enableMove)
			{
				transform.Translate(Vector3.forward * this.WalkSpeed*Time.deltaTime);
				m_Animator.SetFloat("Forward", 2f, .2f, Time.deltaTime);
			}
			else
			{
				m_Animator.SetFloat("Forward", 0f, .2f, Time.deltaTime);
			}
		}
	}
