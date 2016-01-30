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
		if (DataManager.instance.isToggle ()) {
			Debug.Log ("dasdasdasdsadasd");
			audioSrc.Play ();
			Invoke ("PlayNextSong", audioSrc.clip.length);
		}
    }

	void Update() {
		if (PlayerPrefs.GetInt("toggle:") == 0) {
			audioSrc.volume = 1;
		} else {
			audioSrc.volume = 0;
		}
	}

}
