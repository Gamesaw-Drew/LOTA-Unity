using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public float animationDuration = 0.5f;
	public RectTransform handle;
	public RectTransform popup;
	public Text popupText;
    public bool wantPopupAbove;
	float currentPopupScale;
	float currentHandleScale;
	float currentPos;
	bool isSelected;
	int state;
	float animStartTime;
	float animDeltaTime;
	Slider slider;
	Vector3 tempVec3;

	void Start ()
	{
		slider = gameObject.GetComponent<Slider> ();

		popup.gameObject.GetComponent<Image> ().color = handle.gameObject.GetComponent<Image> ().color;

		UpdateText ();
	}

	void Update ()
	{
		UpdateText ();
		if (state == 1)
		{
			animDeltaTime = Time.realtimeSinceStartup - animStartTime;

			if (animDeltaTime <= animationDuration)
			{
				tempVec3 = handle.localScale;
				tempVec3.x = UIAnim.Quint.Out(currentHandleScale, 0.8f, animDeltaTime, animationDuration);
				tempVec3.y = tempVec3.x;
				tempVec3.z = tempVec3.x;
				handle.localScale = tempVec3;
                tempVec3 = popup.localScale;
                tempVec3.x = UIAnim.Quint.Out(currentPopupScale, 1f, animDeltaTime, animationDuration);
                tempVec3.y = tempVec3.x;
                tempVec3.z = tempVec3.x;
                popup.localScale = tempVec3;

                tempVec3 = popup.localPosition;
                if (wantPopupAbove)
                {
                    tempVec3.y = UIAnim.Quint.Out(currentPos, 16f, animDeltaTime, animationDuration);
                }
                popup.localPosition = tempVec3;
			}
			else
			{
				state = 0;
			}
		}
		else if (state == 2)
		{
			animDeltaTime = Time.realtimeSinceStartup - animStartTime;
			
			if (animDeltaTime <= animationDuration)
			{
				tempVec3 = handle.localScale;
				tempVec3.x = UIAnim.Quint.Out(currentHandleScale, 1f, animDeltaTime, animationDuration);
				tempVec3.y = tempVec3.x;
				tempVec3.z = tempVec3.x;
				handle.localScale = tempVec3;
                tempVec3 = popup.localScale;
                tempVec3.x = UIAnim.Quint.Out(currentPopupScale, 0f, animDeltaTime, animationDuration);
                tempVec3.y = tempVec3.x;
                tempVec3.z = tempVec3.x;
                popup.localScale = tempVec3;
            
                tempVec3 = popup.localPosition;
                if (wantPopupAbove)
                {
                    tempVec3.y = UIAnim.Quint.Out(currentPos, 0f, animDeltaTime, animationDuration);
                }
                popup.localPosition = tempVec3;
			}
			else
			{
				state = 0;
			}
		}
	}

	public void UpdateText ()
	{
		float value = Mathf.Round(slider.value * 1.25f + 100);
		popupText.text = (value + "");
	}

	public void OnPointerDown (PointerEventData data)
	{
		currentHandleScale = handle.localScale.x;
		currentPopupScale = popup.localScale.x;
		currentPos = popup.localPosition.y;

		animStartTime = Time.realtimeSinceStartup;

		isSelected = true;
		state = 1;
	}
	
	public void OnPointerUp (PointerEventData data)
	{
		if (isSelected)
		{
			currentHandleScale = handle.localScale.x;
			currentPopupScale = popup.localScale.x;
			currentPos = popup.localPosition.y;
			
			animStartTime = Time.realtimeSinceStartup;

			isSelected = false;
			state = 2;
		}
	}
}
