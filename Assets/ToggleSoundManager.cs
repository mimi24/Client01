using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleSoundManager : MonoBehaviour {
	public Sprite soundOff;
	public Sprite soundOn;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("toggle:") == 0) {
			GetComponent<Button> ().image.overrideSprite = soundOn;
		} else {
			GetComponent<Button> ().image.overrideSprite = soundOff;
		}

	}

	public void OnClick() {
		if (DataManager.instance.isToggle ()) {
			GetComponent<Button> ().image.overrideSprite = soundOn;

		} else {
			GetComponent<Button> ().image.overrideSprite = soundOff;
		}
	}
}
