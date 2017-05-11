using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public CarController m_Car; // the car controller we want to use
		public bool inputEnabled = false;
		private float h;
		private float v;
		private float handbrake;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
		{
			if (inputEnabled) {
				// pass the input to the car!
				h = CrossPlatformInputManager.GetAxis ("Horizontal");
				v = CrossPlatformInputManager.GetAxis ("Vertical");
#if !MOBILE_INPUT
				handbrake = CrossPlatformInputManager.GetAxis ("Jump");
				m_Car.Move (h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
			} else {
				m_Car.Move (0, 0, 0, 1f);
			}
		}
    }
}
