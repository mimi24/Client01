using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private Text timerText;
    public float currentTime;
    public float seconds;
    public float minutes;
    public float roundedSeconds;
    private string tempString;
	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
        Debug.Log(timerText.name);
	}
	
	// Update is called once per frame
	void Update () {

		if(IngameController.instance.isGameOver)
			return;
		
        currentTime += Time.deltaTime;

       // roundedRestSeconds = Mathf.CeilToInt(restSeconds);//
        seconds = currentTime % 60;
        minutes = currentTime / 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerText.text = currentTime.ToString("N0");

    }
}
