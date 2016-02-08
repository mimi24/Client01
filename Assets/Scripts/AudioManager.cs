using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
    public List<AudioClip> audioClips = new List<AudioClip>();
    private AudioSource audioSrc;

    void Awake() {
        audioSrc = GetComponent<AudioSource>();
    }

    void Start() {
        PlayNextSong();
    }
    public void PlayNextSong()
    {
		
        audioSrc.clip = audioClips[Random.Range(0, audioClips.Count)];
		audioSrc.Play ();
		if (DataManager.instance.isToggle ()) {
			Debug.Log ("dasdasdasdsadasd");

			Invoke ("PlayNextSong", audioSrc.clip.length);
		}
    }

	void Update() {
//		if (PlayerPrefs.GetInt("toggle:") == 0) {
//			audioSrc.volume = 1;
//		} else {
//			audioSrc.volume = 0;
//		}
		if (DataManager.instance.isToggle ()) {
			audioSrc.volume = 1;
		} else {
			audioSrc.volume = 0;
		}
	}

}
