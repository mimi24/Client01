using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class IngameController : MonoBehaviour {

	public static IngameController instance;
	public GameObject pausePanel;
	public GameObject gameOverPanel;
	public bool isGameOver = false;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public void OnClickPause()
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void OnClickResume()
	{
		pausePanel.SetActive(false);
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

	public void ShowGameOver()
	{
		gameOverPanel.SetActive(true);
		isGameOver = true;
	}
}
