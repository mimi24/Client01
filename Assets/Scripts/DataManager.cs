using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

	public static DataManager instance;
	public Dictionary<int, List<float>> highScoreList = new Dictionary<int, List<float>>();
	private int highScoreCount = 3;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.X))
			ResetData();
	}

	public int GetLevelIndex()
	{
		int currentStage = SceneManager.GetActiveScene().buildIndex;
		if(currentStage == 9)
			return 1;
		else if(currentStage == 14)
			return 2;
		else if(currentStage == 15)
			return 3;
		else return 0;
	}

	public bool isInCurrentLevel()
	{
		if(GetCurrentLevel() == SceneManager.GetActiveScene().buildIndex)
			return true;
		return false;
	}

	#region CurrentProgress
	public int GetCurrentLevel()
	{
		return PlayerPrefs.GetInt("Level", 1);
	}

	public void SaveCurrentLevel(int levelNum)
	{
		PlayerPrefs.SetInt("Level", levelNum);
	}

	#endregion

	#region Score
		
	public float GetHighScore()
	{
		return PlayerPrefs.GetFloat("Highscore"+SceneManager.GetActiveScene().buildIndex.ToString(), 0f);
	}

	public void SaveHighScore(float value)
	{
		PlayerPrefs.SetFloat("Highscore"+SceneManager.GetActiveScene().buildIndex.ToString(), value);
	}

	public float GetCurrentScore()
	{
		return PlayerPrefs.GetFloat("CurrentScore", 0f);
	}

	public void SaveCurrentScore(float value)
	{
		PlayerPrefs.SetFloat("CurrentScore", value);
	}

	public float GetLevelHighScore()
	{
		string key = GetLevelIndex() +"_"+1.ToString();
		return  PlayerPrefs.GetFloat("HighScoreLevel"+key, 0f);
		
	}

	public void SaveLevelHighScore(int level, string currentName, float currentScore)
	{
		for(int i = 0; i< highScoreCount; i++)
		{
			string key = level.ToString() +"_"+i.ToString();
			float score = PlayerPrefs.GetFloat("HighScoreLevel"+key, 0f);
			string name = PlayerPrefs.GetString("Name"+key, "");

			if(currentScore < score){
				PlayerPrefs.SetFloat("HighScoreLevel"+key, currentScore);
				PlayerPrefs.SetString("Name"+key, currentName);

				currentScore = score;
				currentName = name;
			}
		}
	}

	#endregion


	#region Gems
	public int GetGemCount()
	{
		return PlayerPrefs.GetInt("Gem", 0);
	}

	public void SaveGemCount(int value)
	{
		PlayerPrefs.SetInt("Gem", value);
	}
	#endregion

	public void ResetData()
	{
		Debug.Log("Reset Data ----->");
		PlayerPrefs.DeleteAll();
		
	}
}
