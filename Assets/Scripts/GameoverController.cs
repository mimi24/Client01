using UnityEngine;
using System.Collections;

public class GameoverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
		
	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			IngameController.instance.ShowGameOver();
			gameObject.SetActive(false);
			Debug.Log("collide on flag");
		}
	}
}
