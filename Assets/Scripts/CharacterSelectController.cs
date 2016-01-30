using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelectController : MonoBehaviour {

	public static CharacterSelectController instance;
	public List<GameObject> characters = new List<GameObject>();

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		characters[DataManager.instance.GetCharacter()].SetActive(true);
		if(DataManager.instance.GetCharacter() > 0)
			characters[0].SetActive(false);
	}

	public void UpdateCharacter(int charID)
	{
		for(int i = 0; i < characters.Count; i++)
		{
			if(charID == i)
				characters[i].SetActive(true);
			else
				characters[i].SetActive(false);
		}	
	}
}
