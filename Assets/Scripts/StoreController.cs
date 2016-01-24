using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreController : MonoBehaviour {

	public Text gemCountText;
	private int gemCount = 0;

	// Use this for initialization
	void OnEnable () {
		HeaderController.instance.activePanel = gameObject;
		HeaderController.instance.ActivateHeader(true);
		gemCount =  DataManager.instance.GetGemCount();
		gemCountText.text = gemCount.ToString();
	}

	public void OnClickBuy(int id)
	{
		int price = GetPrice(id);
		gemCount -= price;
		gemCountText.text = gemCount.ToString();
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
