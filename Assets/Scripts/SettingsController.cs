using UnityEngine;
using System.Collections;

public class SettingsController : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		HeaderController.instance.activePanel = gameObject;
		HeaderController.instance.ActivateHeader(true);
	}
}
