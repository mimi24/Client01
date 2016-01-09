using UnityEngine;
using System.Collections;

public class StoreController : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		HeaderController.instance.activePanel = gameObject;
		HeaderController.instance.ActivateHeader(true);
	}
}
