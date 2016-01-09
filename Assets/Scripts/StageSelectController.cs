using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour {

	public List<GameObject> stages = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable(){
		HeaderController.instance.activePanel = gameObject;
		HeaderController.instance.ActivateHeader(false);
	}

	public void OnClickStages(int stageNum){
		SceneManager.LoadScene(stageNum);
	}

}
