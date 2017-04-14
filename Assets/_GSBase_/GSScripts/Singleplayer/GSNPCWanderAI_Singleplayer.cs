using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    

    [RequireComponent(typeof(Animator))]
    public class GSNPCWanderAI_Singleplayer : MonoBehaviour {
     
        public float wanderRadius;
        public float wanderTimer;
        float wanderTimerMin = 5.0f;
        float wanderTimerMax = 40.0f;
     
        private Transform target;
        private UnityEngine.AI.NavMeshAgent agent;
        private float timer;
        public ThirdPersonCharacter character{get; private set;}
        Animator charanimator;
        Vector3 movement;
        float forwardAmount;
        float turnAmount;
     
        void OnEnable()
        {
            charanimator = GetComponent<Animator>();
            character = GetComponent<ThirdPersonCharacter>();
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            timer = wanderTimer;
        }
     
        void FixedUpdate()
        {
            wanderTimer = Random.Range(wanderTimerMin, wanderTimerMax);
            timer += Time.deltaTime;
     
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
            CharacterAnimation(agent.desiredVelocity);
        }
     
        public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
        {
            Vector3 randDirection = Random.insideUnitSphere * dist;
     
            randDirection += origin;
     
            UnityEngine.AI.NavMeshHit navHit;
     
            UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
     
            return navHit.position;
        }
        void CharacterAnimation(Vector3 movement)
        {
            if (movement.magnitude > 1f) movement.Normalize();
            movement = transform.InverseTransformDirection(movement);
            forwardAmount = movement.z;
            turnAmount = Mathf.Atan2(movement.x, movement.z);
            if(turnAmount < 0f)
            {
                turnAmount = (turnAmount * -1f);
            }
            charanimator.SetFloat("Forward", forwardAmount * 2.0f, 0.2f, Time.deltaTime);
            charanimator.SetFloat("Forward", turnAmount, 0.2f, Time.deltaTime);
            
        }
            
    }
}
 