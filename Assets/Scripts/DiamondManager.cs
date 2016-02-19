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

		if (PlayerPrefs.GetInt ("ResetAll") == 1) {
			Debug.Log ("here is reset all");
			PlayerPrefs.SetInt ("ResetAll", 0);
			for (int i = 0; i < diamondList.Count; i++) {
				//PlayerPrefs.SetInt (sceneName + ":" + i.ToString ());
//				Debug.Log(sceneName+ ":"+ i.ToString()+ " status:");
				PlayerPrefs.SetInt (sceneName + ":" + i.ToString () + " status:", 0);
				Debug.Log(sceneName+ ":"+ i.ToString()+ " status:" +PlayerPrefs.GetInt(sceneName+ ":"+ i.ToString()+ " status:") );
				Debug.Log ("reset all gems wahaha");
			}
		} else {
			for (int i = 0; i < diamondList.Count; i++) {
				//PlayerPrefs.SetInt (sceneName + ":" + i.ToString ());
				Debug.Log(sceneName+ ":"+ i.ToString()+ " status:" +PlayerPrefs.GetInt(sceneName+ ":"+ i.ToString()+ " status:") );
				if(PlayerPrefs.GetInt(sceneName+ ":"+ i.ToString()+ " status:") == 1) {
					Debug.Log(sceneName+ ":"+ i.ToString()+ " status:" +PlayerPrefs.GetInt(sceneName+ ":"+ i.ToString()+ " status:") );
					diamondList [i].SetActive (false);
				}

			}
		
		}

//		for (int i = 0; i < diamondList.Count; i++) {
//			//PlayerPrefs.SetInt (sceneName + ":" + i.ToString ());
//			Debug.Log(sceneName+ ":"+ i.ToString()+ " status:");
//			if(PlayerPrefs.GetInt(sceneName+ ":"+ i.ToString()+ " status:") == 1) {
//				diamondList [i].SetActive (false);
//			}
//
//		}
	}

	public void SavePickedGem(GameObject gem) {
		int currentGemIndex = diamondList.IndexOf (gem);
		PlayerPrefs.SetInt (sceneName + ":" + currentGemIndex.ToString()+" status:", 1);
	}

	public void ResetGemScene() {
		Scene[] sceneList = SceneManager.GetAllScenes ();
		for (int i = 1; i < sceneList.Length; i++) {
			PlayerPrefs.SetInt (sceneList [i].name + ":" + i.ToString () + " status:", 0);
			Debug.Log (sceneList [i].name);
			Debug.Log(PlayerPrefs.GetInt(sceneList [i].name+ ":"+ i.ToString()+ " status:"));
		}

	}
}
