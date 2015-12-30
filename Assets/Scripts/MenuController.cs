using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject menubtn;
	public GameObject settingsbtn;
	public GameObject highScorebtn;
	public GameObject storebtn;
	public GameObject levelSelectPanel;


	// Use this for initialization
	void Start () {
	
	}

	public void OnClickPlay(){
		//TODO: Transition Animation
		menubtn.SetActive(false);
		levelSelectPanel.SetActive(true);	
	}
}
