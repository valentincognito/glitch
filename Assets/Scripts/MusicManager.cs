using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangerArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (this);
	}	
	
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangerArray [level];

		if(thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.volume = 0.5f;
			audioSource.Play();
		}
	}
}
