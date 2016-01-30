using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

	public static DataManager instance;
	private int highScoreCount = 3;

	// Use this for initialization
	void Awake () {
		instance = this;


		if (PlayerPrefs.GetInt ("toggle:") == 0) {

		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.X))
			ResetData();
	}

	public int GetCurrentMazeIndex()
	{
		return SceneManager.GetActiveScene().buildIndex;
	}

	public int GetPerDifficultyIndex()
	{
		int currentStage =  GetCurrentMazeStage();
		if(currentStage < 10)
			return 0;
		else if(currentStage < 15)
			return 1;
		else if(currentStage == 15)
			return 2;
		else
			return 0;
	}

	public string GetPlayerName()
	{
		return PlayerPrefs.GetString("PlayerName", null);
	}

	public void SetPlayerName(string name)
	{
		PlayerPrefs.SetString("PlayerName",name);
	}

	public bool isInCurrentLevel()
	{
		if(GetCurrentMazeStage() == SceneManager.GetActiveScene().buildIndex)
			return true;
		return false;
	}

	#region CurrentProgress
	public int GetCurrentMazeStage()
	{
		return PlayerPrefs.GetInt("Level", 1);
	}

	public void SaveCurrentMazeStage()
	{
		PlayerPrefs.SetInt("Level", GetCurrentMazeIndex() + 1);
	}

	public void ResetCurrentMazeStage()
	{
		PlayerPrefs.SetInt("Level", 1);
		SetPlayerName(null);
		ResetLocalHighScore();
	}

	#endregion

	#region Score

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
		string key = GetPerDifficultyIndex() +"_"+1.ToString();
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

	public void SaveMazeHighScore(float currentScore)
	{
		string currentName = GetPlayerName();
		int level = GetCurrentMazeIndex();

		for(int i = 0; i< highScoreCount; i++)
		{
			string key = level.ToString() +"_"+i.ToString();
			float score = PlayerPrefs.GetFloat("HighScorePerMaze"+key, 0f);
			string name = PlayerPrefs.GetString("NamePerMaze"+key,null);
		
			if(score == 0f)
			{
				PlayerPrefs.SetFloat("HighScorePerMaze"+key, currentScore);
				PlayerPrefs.SetString("NamePerMaze"+key, currentName);

				currentScore = score;
				currentName = name;
			}

			else if(currentScore < score){
				PlayerPrefs.SetFloat("HighScorePerMaze"+key, currentScore);
				PlayerPrefs.SetString("NamePerMaze"+key, currentName);

				currentScore = score;
				currentName = name;
			}

//			Debug.Log(i +" last name: " + name + "last score: " + score);
//			Debug.Log("key : " + key);
//			Debug.Log(i +" name: " + PlayerPrefs.GetString("NamePerMaze"+key) + "score: " +  PlayerPrefs.GetFloat("HighScorePerMaze"+key));

		}
	}

	public float GetMazeHighScore()
	{
		string key =  GetCurrentMazeIndex() +"_"+0.ToString();
		return  PlayerPrefs.GetFloat("HighScorePerMaze"+key, 0f);
	}

	public float GetMazeHighScore(int mazeIndex, int rank)
	{
		string key =  mazeIndex +"_"+rank.ToString();
		return  PlayerPrefs.GetFloat("HighScorePerMaze"+key, 0f);
	}

	public string GetMazeHighScoreName(int mazeIndex, int rank)
	{
		string key = mazeIndex +"_"+rank.ToString();
		return  PlayerPrefs.GetString("NamePerMaze"+key, "");
	}

	public void SaveLocalHighScore(float currentScore)
	{
		PlayerPrefs.SetFloat("LocalHighScore"+GetCurrentMazeIndex().ToString(),currentScore);
	}

	public float GetLocalHighScore(int mazeIndex)
	{
		return PlayerPrefs.GetFloat("LocalHighScore"+mazeIndex.ToString(), 0f);
	}

	private void ResetLocalHighScore()
	{
		for(int i = 0; i < 15; i++)
		{
			PlayerPrefs.SetFloat("LocalHighScore"+ (i+1).ToString(),0f);
		}
	}

	public void SaveOverallHighScore(float currentScore, int overallIndex)
	{
		string currentName = GetPlayerName();
		int level = overallIndex;

		for(int i = 0; i< highScoreCount; i++)
		{
			string key = level.ToString() +"_"+i.ToString();
			float score = PlayerPrefs.GetFloat("HighScoreOverall"+key, 0f);
			string name = PlayerPrefs.GetString("NameOverall"+key,null);

			if(score == 0f)
			{
				PlayerPrefs.SetFloat("HighScoreOverall"+key, currentScore);
				PlayerPrefs.SetString("NameOverall"+key, currentName);

				currentScore = score;
				currentName = name;
			}

			else if(currentScore < score){
				PlayerPrefs.SetFloat("HighScoreOverall"+key, currentScore);
				PlayerPrefs.SetString("NameOverall"+key, currentName);

				currentScore = score;
				currentName = name;
			}

			//			Debug.Log(i +" last name: " + name + "last score: " + score);
			//			Debug.Log("key : " + key);
			//			Debug.Log(i +" name: " + PlayerPrefs.GetString("NamePerMaze"+key) + "score: " +  PlayerPrefs.GetFloat("HighScorePerMaze"+key));

		}
	}

	public float GetOverallScore(int overallIndex, int rank)
	{
		string key =  overallIndex +"_"+rank.ToString();
		return  PlayerPrefs.GetFloat("HighScoreOverall"+key, 0f);
	}

	public string GetOverallName(int overallIndex, int rank)
	{
		string key = overallIndex +"_"+rank.ToString();
		return  PlayerPrefs.GetString("NameOverall"+key, "");
	}


	public void SaveOverallScore()
	{
		float easy = 0f;
		float medium = 0f;
		float hard = 0f;

		for(int i = 0; i < 15; i++)
		{
			float score = GetLocalHighScore(i+1);

			if(score == 0f){
				break; return;
			}

			if(i+1 < 10) //easy
				easy += score;
			else if(i+1 < 15) //medium
				medium += score;
			else if(i+1 == 15) //hard
				hard += score;
		}

		SaveOverallHighScore(easy, 0);
		SaveOverallHighScore(medium, 1);
		SaveOverallHighScore(hard, 2);
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

	bool hasToggle = false;
	public void ToggleSounds() {
		
		if (PlayerPrefs.GetInt ("toggle:") == 0) {
			hasToggle = true;
		} else {
			hasToggle = false;
		}
	}
	public bool isToggle() {
		return hasToggle;
	}
}
