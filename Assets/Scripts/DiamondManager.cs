using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DiamondManager : MonoBehaviour {
	public string sceneName;
	public List<GameObject> diamondList = new List<GameObject>();
	public static DiamondManager instance;
	void Start() {
		if (instance == null)
			instance = this;
		
		sceneName = SceneManager.GetActiveScene ().name;

		for (int y = 0; y < transform.childCount; y++) {
			diamondList.Add(transform.GetChild(y).gameObject);
		}
		for (int i = 0; i < diamondList.Count; i++) {
			//PlayerPrefs.SetInt (sceneName + ":" + i.ToString ());

			if(PlayerPrefs.GetInt(sceneName+ ":"+ i.ToString()+ " status:") == 1) {
				diamondList [i].SetActive (false);
			}

		}
	}

	public void SavePickedGem(GameObject gem) {
		int currentGemIndex = diamondList.IndexOf (gem);
		PlayerPrefs.SetInt (sceneName + ":" + currentGemIndex.ToString()+" status:", 1);
	}
}
