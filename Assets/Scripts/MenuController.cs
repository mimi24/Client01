using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject settingsPanel;
	public GameObject HighScorePanel;
	public GameObject storePanel;
	public GameObject levelSelectPanel;
	public GameObject newGamePanel;
	public GameObject continuePanel;
	public GameObject warningPanel;

	public InputField inputNameField;
	public Button okButton;
	public Text name;
	public AudioClip btnSound;
	public AudioSource audioSource;

	private GameObject menuPanel;
	private string playerName;

	// Use this for initialization
	void Start () {
		audioSource.clip = btnSound;
		audioSource.playOnAwake = false;
		menuPanel = transform.GetChild(0).gameObject;
		playerName =  DataManager.instance.GetPlayerName();
		Debug.Log(playerName);
		DataManager.instance.SaveOverallScore();
	}

	public void OnClickPlay(){
		//TODO: Transition Animation

		if(playerName == null || playerName == ""){
			LoadNewGame();
		}
		else
			continuePanel.SetActive(true);
		
		menuPanel.SetActive(false);
		name.text = "Hi " + playerName;
	}

	public void OnClickSettings(){
		settingsPanel.SetActive(true);
		menuPanel.SetActive(false);
	}

	public void OnClickStore(){
		storePanel.SetActive(true);
		menuPanel.SetActive(false);
	}

	public void OnClickHighScore()
	{
		HighScorePanel.SetActive(true);
		menuPanel.SetActive(false);
	}

	public void OnClickOk()
	{
		levelSelectPanel.SetActive(true);	
		newGamePanel.SetActive(false);
		continuePanel.SetActive(false);
		warningPanel.SetActive(false);

		DataManager.instance.SetPlayerName(playerName);
	}

	public void OnClickNewGame()
	{
		warningPanel.SetActive(true);
	}

	public void OnClickNewGame2()
	{
		LoadNewGame();
		continuePanel.SetActive(false);
	}

	public void OnClickCancel2()
	{
		warningPanel.SetActive(false);
	}

	public void OnClickCancel()
	{
		newGamePanel.SetActive(false);
		menuPanel.SetActive(true);
	}

	public void OnEnterName()
	{
		if(inputNameField.text.Length != 0)
			okButton.interactable = true;
		else
			okButton.interactable = false;

		playerName = inputNameField.text;
	}

	private void LoadNewGame()
	{
		newGamePanel.SetActive(true);
		inputNameField.text = "";
		playerName = null;
		DataManager.instance.ResetCurrentMazeStage();
	}

	public void PlayBtnSound() {
		Debug.Log ("PlayBtnSound");
		if (DataManager.instance.isToggle ()) {
			audioSource.PlayOneShot (btnSound);
		}

	}

}