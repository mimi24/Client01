using UnityEngine;
using System.Collections;

public class HeaderController : MonoBehaviour {
	
	public static HeaderController instance;
	public GameObject menuPanel;
	public GameObject levelSelectPanel;
	public GameObject activePanel;

	public GameObject menuBtn;
	public GameObject levelSelectBtn;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void DeactivateHeader()
	{
		menuBtn.SetActive(false);
		levelSelectBtn.SetActive(false);
	}

	public void ActivateHeader(bool onLevelSelect){
		menuBtn.SetActive(true);

		if(!onLevelSelect)
			levelSelectBtn.SetActive(true);	
	}

	
	public void OnClickMenu()
	{
		activePanel.SetActive(false);
		menuPanel.SetActive(true);
		DeactivateHeader();
	}

	public void OnClickLevels()
	{
		activePanel.SetActive(false);
		levelSelectPanel.SetActive(true);
		levelSelectBtn.SetActive(false);
	}
}
