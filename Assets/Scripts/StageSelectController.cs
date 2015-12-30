using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour {

	public List<GameObject> stages = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}

	public void OnClickStages(int stageNum){
		SceneManager.LoadScene(stageNum);
	}

}
