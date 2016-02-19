using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StoreController : MonoBehaviour {

	public Text gemCountText;
	public List<Character> characters = new List<Character>();
	public GameObject confirmPanel;
	private int gemCount = 0;
	private int price = 0;
	private int charID = 0;

	// Use this for initialization
	void OnEnable () {
		HeaderController.instance.activePanel = gameObject;
		HeaderController.instance.ActivateHeader(true);
		gemCount =  DataManager.instance.GetGemCount();
		gemCountText.text = gemCount.ToString();
		Init();
	}

	void Init()
	{
		for(int i = 0; i < characters.Count; i++)
		{
			if(i == DataManager.instance.GetBoughtCharacter())
			{
				characters[i].btnBuy.gameObject.SetActive(false);
				characters[i].btnUse.gameObject.SetActive(true);
				Debug.Log (characters [i].gameObject);
			}

			if (DataManager.instance.GetCharacter () == i) {
				characters[i].btnUse.interactable = false;
			}
				
			else {
				Debug.Log (DataManager.instance.GetCharacter ());
				characters[i].btnUse.interactable = true;
			}
				

			if (gemCount < GetPrice (i)) {
				characters[i].btnBuy.interactable = false;
			}
				
		}
	}

	public void OnClickBuy(int id)
	{
		price = GetPrice(id);
		charID = id;
		confirmPanel.SetActive(true);
	}

	public void OnClickUse(int id)
	{
		for(int i = 0; i < characters.Count; i++)
		{
			if(id == i)
				characters[i].btnUse.interactable = false;
			else
				characters[i].btnUse.interactable = true;
		}

		DataManager.instance.SetCharacter(id);
		CharacterSelectController.instance.UpdateCharacter(id);
	}

	public void OnClickOk()
	{
		gemCount -= price;
		gemCount = Mathf.Clamp(gemCount, 0, gemCount);
		gemCountText.text = gemCount.ToString();
		DataManager.instance.SetBoughtCharacter(charID);
		DataManager.instance.SaveGemCount(gemCount);
		Init();
		confirmPanel.SetActive(false);
	}

	public void OnClickCancel()
	{
		confirmPanel.SetActive(false);
	}

	private int GetPrice(int id)
	{
		switch(id)
		{
			case 1 :  return 15; break;
			case 2 :  return 30; break;
			case 3 :  return 40; break;
			default :  return 0; break;
		}
	}
}
