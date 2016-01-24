using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage : MonoBehaviour {

	public int stageNum;
	public bool isLevel = false;

	// Use this for initialization
	void Start () {
		if(stageNum <= DataManager.instance.GetCurrentMazeStage())
			UnlockStage();
	}

	void UnlockStage()
	{
		GetComponent<Button>().interactable = true;
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
