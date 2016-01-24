using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[Serializable]
public struct ScoreList{
	public Text name;
	public Text score;
}

public class HighScoreController : MonoBehaviour {

	public List<ScoreList> perMazeHighScore = new List<ScoreList>();
	public List<ScoreList> overallHighScore = new List<ScoreList>();


	void OnEnable () {
		DisplayHighScores();
		DisplayOverallHighScores();
		HeaderController.instance.activePanel = gameObject;
		HeaderController.instance.ActivateHeader(true);
	}

	void DisplayHighScores()
	{
		for(int i = 0; i < perMazeHighScore.Count; i++)
		{
			string name = "";
			string score = "";

			for(int j =0; j < 3; j++){
				float _score = DataManager.instance.GetMazeHighScore(i+1, j);
				string _name = DataManager.instance.GetMazeHighScoreName(i+1, j);
			
				if(_score == 0f)
				{
					name += (j+1).ToString() + ". - \n";
					score += "- \n";
				}
				else
				{
					name += (j+1).ToString() + ". " + _name + "\n";
					score += string.Format("{0:00}:{1:00} \n", _score/60, _score % 60);
				}

				perMazeHighScore[i].name.text = name;
				perMazeHighScore[i].score.text = score;

			}
		}
	}

	void DisplayOverallHighScores()
	{
		for(int i = 0; i < overallHighScore.Count; i++)
		{
			string name = "";
			string score = "";

			for(int j =0; j < 3; j++){
				float _score = DataManager.instance.GetOverallScore(i, j);
				string _name = DataManager.instance.GetOverallName(i, j);

				if(_score == 0f)
				{
					name += (j+1).ToString() + ". - \n";
					score += "- \n";
				}
				else
				{
					name += (j+1).ToString() + ". " + _name + "\n";
					score += string.Format("{0:00}:{1:00} \n", _score/60, _score % 60);
				}

				overallHighScore[i].name.text = name;
				overallHighScore[i].score.text = score;

			}
		}
	}


}
