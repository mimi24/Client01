using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

	public GameObject levelSelect;
	public GameObject easyLevel;
	public GameObject averagePanel;
	public GameObject difficultPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	public void OnClickEasy(){
		levelSelect.SetActive(false);
		easyLevel.SetActive(true);
	}

	public void OnClickAverage(){
		levelSelect.SetActive(false);
		averagePanel.SetActive(true);
	}

	public void OnClickHard(){
		levelSelect.SetActive(false);
		difficultPanel.SetActive(true);
	}
}
