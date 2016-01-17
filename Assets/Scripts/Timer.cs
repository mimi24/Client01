using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {
	
	public static Timer instance;
	private Text timerText;
	public float timeTobeat;
    public float currentTime;
    public float seconds;
    public float minutes;
    public float roundedSeconds;
  
	private string tempString;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();

		// if in current progress
		if(DataManager.instance.isInCurrentLevel()){
			currentTime = DataManager.instance.GetCurrentScore();
			timeTobeat =  DataManager.instance.GetLevelHighScore();
			DisplayTime(true, timerText);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(IngameController.instance.isGameOver)
		{
			SaveProgressData();
			return;
		}
		
        currentTime += Time.deltaTime;
		DisplayTime(true, timerText);
    }

	public void DisplayTime(bool isCurrentTime, Text uitext)
	{
		float time = isCurrentTime ? currentTime : timeTobeat;
		seconds = time % 60;
		minutes = time / 60;
		uitext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	void SaveProgressData()
	{
//		if(timeTobeat == 0f)
//			DataManager.instance.SaveHighScore(currentTime);
//
//		else if(currentTime < timeTobeat)
//		{
//			timeTobeat = currentTime;
//			DataManager.instance.SaveHighScore(timeTobeat);
//		}

		if(DataManager.instance.isInCurrentLevel())
		{
			DataManager.instance.SaveCurrentLevel(SceneManager.GetActiveScene().buildIndex + 1);
			DataManager.instance.SaveCurrentScore(currentTime);
		}
	}
}
