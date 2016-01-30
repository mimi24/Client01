using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class IngameController : MonoBehaviour{

	public static IngameController instance;
	public GameObject pausePanel;
	public GameObject gameOverPanel;
	public Text gemText;
	public bool isGameOver = false;
	public bool isPaused = false;
	public GameObject mobileJoyStick;
	public AudioClip btnSound;
	public AudioClip gemSound;
	public AudioClip finishSound;
	public AudioSource audioSource;

	private int gemCounter = 0;

	// Use this for initialization
	void Awake () {
		instance = this;
		audioSource.clip = btnSound;
		audioSource.playOnAwake = false;
	}

	void Start(){
		gemCounter = DataManager.instance.GetGemCount();
		gemText.text = gemCounter.ToString();
	}

	public void UpdateGem()
	{
		audioSource.clip = gemSound;
		if (DataManager.instance.isToggle ()) {
			audioSource.PlayOneShot (gemSound);
		}
		gemCounter++;
		DataManager.instance.SaveGemCount(gemCounter);
		gemText.text = gemCounter.ToString();
	}

	public void ShowGameOver()
	{
		audioSource.clip = finishSound;
		if (DataManager.instance.isToggle ()) {
			audioSource.PlayOneShot (finishSound);
		}
		//isGameOver = true;
		gameOverPanel.SetActive(true);
	}
	
	public void OnClickPause()
	{
		PlayBtnSound ();
		pausePanel.SetActive(true);
		isPaused = true;
		Time.timeScale = 0f;
	}

	public void OnClickResume()
	{
		PlayBtnSound ();
		PlayBtnSound ();
		pausePanel.SetActive(false);
		isPaused = false;
		Time.timeScale = 1f;
	}

	public void OnClickRestart()
	{
		PlayBtnSound ();
		Time.timeScale = 1f;
		LoadingController.instance.FadeIn();
		Invoke("Restart", 0.5f);
	}

	public void OnClickNext()
	{
		PlayBtnSound ();
		LoadingController.instance.FadeIn();

		if(DataManager.instance.GetCurrentMazeIndex() == 15)
			Invoke("LoadMenu", 0.5f);
		else
			Invoke("LoadNext", 0.5f);
	}

	void LoadNext()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnClickMenu()
	{
		PlayBtnSound ();
		Time.timeScale = 1f;
		LoadingController.instance.FadeIn();
		Invoke("LoadMenu", 0.5f);
	}

	public void OnClickLevel()
	{
		PlayBtnSound ();
		Time.timeScale = 1f;
	}

	void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void PlayBtnSound() {
		Debug.Log ("PlayBtnSound");
		if (DataManager.instance.isToggle ()) {
			audioSource.PlayOneShot (btnSound);
		}

	}
}
