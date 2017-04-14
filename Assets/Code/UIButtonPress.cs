using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonPress : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {

	private AudioSource audioSource;
	public AudioClip hoverClip;
	public AudioClip pressClip;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.playOnAwake = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		audioSource.clip = pressClip;
		audioSource.Play();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		audioSource.clip = hoverClip;
		audioSource.Play();
	}
}
