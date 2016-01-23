using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage : MonoBehaviour {

	public int stageNum;
	public bool isLevel = false;

	// Use this for initialization
	void Start () {
		if(isLevel)
		{
			if(DataManager.instance.isInCurrentLevel())
				UnlockStage();
		}
		else
		{
			if(stageNum <= DataManager.instance.GetCurrentLevel())
				UnlockStage();
		}
	}

	void UnlockStage()
	{
		GetComponent<Button>().interactable = true;
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
