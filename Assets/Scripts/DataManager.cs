using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

	public static DataManager instance;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
		
	public float GetHighScore()
	{
		return PlayerPrefs.GetFloat("Highscore"+SceneManager.GetActiveScene().buildIndex.ToString(), 0f);
	}

	public void SaveHighScore(float value)
	{
		PlayerPrefs.SetFloat("Highscore"+SceneManager.GetActiveScene().buildIndex.ToString(), value);
	}

	public int GetGemCount()
	{
		return PlayerPrefs.GetInt("Gem", 0);
	}

	public void SaveGemCount(int value)
	{
		PlayerPrefs.SetInt("Gem", value);
	}

	public void ResetData()
	{
		
	}
}
