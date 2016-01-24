using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameoverController : MonoBehaviour {

	public Text gemText;
	public Text currentTimeText;
	public Text highScoreText;

	public List<GameObject> stars = new List<GameObject>();

	// Use this for initialization
	void OnEnable () {
		gemText.text = DataManager.instance.GetGemCount().ToString();
		Timer.instance.DisplayTime(true, currentTimeText);
		Timer.instance.DisplayTime(false, highScoreText);

		StartCoroutine(AnimateStar());
		//DisplayHighScore();
	}

	IEnumerator AnimateStar()
	{
		for(int i = 0; i < stars.Count; i++)
		{
			GameObject star = stars[i].transform.GetChild(0).gameObject;
			star.SetActive(true);
			iTween.ScaleFrom(star, iTween.Hash(
				"scale", Vector3.one * 3f,
				"time", 0.3f,
				"islocal", true
			));
			yield return new WaitForSeconds(0.3f);
			
		}
	}

	void DisplayHighScore()
	{
		int levelIndex = DataManager.instance.GetPerDifficultyIndex();
		if(levelIndex != 0){
			Timer.instance.DisplayTime(false, highScoreText);
			highScoreText.transform.parent.gameObject.SetActive(true);
			DataManager.instance.SaveCurrentScore(0f);
		}
	}
}
