using UnityEngine;
using System.Collections;
 
public class Billboard : MonoBehaviour
{
    public Camera m_Camera;
	public bool followMinimap = false;

	void Start()
	{
		if (followMinimap) {
			m_Camera = GameObject.FindWithTag ("MinimapCam").GetComponent<Camera> ();
		} else {
			m_Camera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera> ();
		}
	}
 
    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}