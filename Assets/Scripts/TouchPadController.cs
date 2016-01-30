using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class TouchPadController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
	public GameObject joystick;
	public void OnPointerUp(PointerEventData data)
	{

	}


	public void OnPointerDown(PointerEventData data) {
		joystick.transform.position = Input.mousePosition;
		joystick.GetComponent<Joystick> ().m_StartPos = Input.mousePosition;
		joystick.GetComponent<Joystick> ().OnDrag (data);
	}
}
