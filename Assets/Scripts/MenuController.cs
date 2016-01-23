using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject settingsPanel;
	public GameObject HighScorePanel;
	public GameObject storePanel;
	public GameObject levelSelectPanel;


	// Use this for initialization
	void Start () {
	
	}

	public void OnClickPlay(){
		//TODO: Transition Animation
		levelSelectPanel.SetActive(true);	
		gameObject.SetActive(false);
	}

	public void OnClickSettings(){
		settingsPanel.SetActive(true);
		gameObject.SetActive(false);
	}

	public void OnClickStore(){
		storePanel.SetActive(true);
		gameObject.SetActive(false);
	}

	public void OnClickHighScore()
	{
		HighScorePanel.SetActive(true);
		gameObject.SetActive(false);
	}
}
