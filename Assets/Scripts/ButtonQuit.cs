using UnityEngine;
using System.Collections;

public class ButtonQuit : MonoBehaviour {

	public GameObject quitPanel;

	public void OnClickQuit()
	{
		quitPanel.SetActive(true);
	}

	public void OnClickYes()
	{
		Application.Quit();
	}

	public void OnClickNo()
	{
		quitPanel.SetActive(false);
	}

}
