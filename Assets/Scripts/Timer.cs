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
	private bool saveOnce = false;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();

		// if in current progress
//		if(DataManager.instance.isInCurrentLevel()){
//			currentTime = DataManager.instance.GetCurrentScore();
//			timeTobeat =  DataManager.instance.GetLevelHighScore();
//			DisplayTime(true, timerText);
//		}

		currentTime = 0f;
		timeTobeat = DataManager.instance.GetMazeHighScore();
	}
	
	// Update is called once per frame
	void Update () {
		if(IngameController.instance.isGameOver /* || IngameController.instance.isPaused */)
		{
			SaveProgressData();
			return;
		}
		
        currentTime += Time.deltaTime;
		DisplayTime(true, timerText);
    }

	public void DisplayTime(bool isCurrentTime, Text uitext)
	{
		float time = isCurrentTime ? currentTime : DataManager.instance.GetMazeHighScore();
		seconds = time % 60;
		minutes = time / 60;
		uitext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	void SaveProgressData()
	{
		if(saveOnce)
			return;
	
		saveOnce = true;
		if(timeTobeat == 0f){
			timeTobeat = currentTime;
			DataManager.instance.SaveMazeHighScore(timeTobeat);
		}

		else if(currentTime < timeTobeat)
		{
			timeTobeat = currentTime;
			DataManager.instance.SaveMazeHighScore(timeTobeat);
		}

		//Save locally to get overall
		float localScore = DataManager.instance.GetLocalHighScore(DataManager.instance.GetCurrentMazeIndex());
		if(localScore == 0f)
			DataManager.instance.SaveLocalHighScore(currentTime);
		
		else if(currentTime < localScore)
			DataManager.instance.SaveLocalHighScore(currentTime);
		
	
		if(DataManager.instance.GetCurrentMazeIndex() >= DataManager.instance.GetCurrentMazeStage())
			DataManager.instance.SaveCurrentMazeStage();
		
//		if(DataManager.instance.isInCurrentLevel())
//		{
//			DataManager.instance.SaveCurrentLevel(SceneManager.GetActiveScene().buildIndex + 1);
//			DataManager.instance.SaveCurrentScore(currentTime);
//		}
	}
}
