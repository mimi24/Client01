using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {

	public static LoadingController instance;
	CanvasGroup loadingCanvas;
	Image _image;

	void Awake()
	{
		instance = this;
		loadingCanvas = GetComponent<CanvasGroup>();
		_image = GetComponent<Image>();
	}

	void Start()
	{
		_image.CrossFadeAlpha(1f, 0f, true);
		Invoke("FadeOUt", 0.5f);
	}


	void OnLevelWasLoaded(int level)
	{
		Invoke("FadeOUt", 0.5f);
	}

	public void FadeIn()
	{
		_image.CrossFadeAlpha(1f, 0.5f, true);
	}

	public void FadeOUt()
	{
		_image.CrossFadeAlpha(0f, 0.5f, true);

	}
}
