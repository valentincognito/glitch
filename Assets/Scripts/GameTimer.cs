using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 30f;
	public AudioSource audioSource;
	public LevelManager levelManager;

	private Slider slider;
	private GameObject winLabel;
	private bool isEndOfLevel = false;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		winLabel = GameObject.Find("Win Text");
		winLabel.SetActive (false);

		slider.value = Time.timeSinceLevelLoad / levelSeconds;
	}
	
	// Update is called once per frame
	void Update () {

		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel){
			audioSource.Play ();
			winLabel.SetActive (true);
			Invoke("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}

	}
		

	private void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
