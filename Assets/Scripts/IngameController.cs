using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameController : MonoBehaviour {

	public static IngameController instance;
	public GameObject pausePanel;
	public GameObject gameOverPanel;
	public Text gemText;
	public bool isGameOver = false;
	public bool isPaused = false;

	private int gemCounter = 0;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start(){
		gemCounter = DataManager.instance.GetGemCount();
		gemText.text = gemCounter.ToString();
	}

	public void UpdateGem()
	{
		gemCounter++;
		DataManager.instance.SaveGemCount(gemCounter);
		gemText.text = gemCounter.ToString();
	}

	public void ShowGameOver()
	{
		gameOverPanel.SetActive(true);
		isGameOver = true;
	}
	
	public void OnClickPause()
	{
		pausePanel.SetActive(true);
		isPaused = true;
		Time.timeScale = 0f;
	}

	public void OnClickResume()
	{
		pausePanel.SetActive(false);
		isPaused = false;
		Time.timeScale = 1f;
	}

	public void OnClickRestart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnClickNext()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OnClickMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	public void OnClickLevel()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
}
