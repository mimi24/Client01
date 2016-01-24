using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.tag == "Diamond") {
			iTween.MoveTo(col.gameObject, iTween.Hash("y", 1f,"time",5f));
			IngameController.instance.UpdateGem();
			Destroy(col.gameObject, 2f);
		}

		if (col.tag == "Flag") {
			Invoke("ShowGameOver", 0.5f);
			IngameController.instance.isGameOver = true;
			col.gameObject.SetActive(false);
		}
	}

	void ShowGameOver()
	{
		IngameController.instance.ShowGameOver();
	}
}
