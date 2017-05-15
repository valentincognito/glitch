using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int stars = 0;

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text> ();
		starText.text = stars.ToString();
	}

	public void AddStars(int amount){
		stars += amount;
		starText.text = stars.ToString ();
	}

	public void UseStars(int amount){
		stars -= amount;
		starText.text = stars.ToString ();
	}
}
