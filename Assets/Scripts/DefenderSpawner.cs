using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarDisplay starDisplay;

	void Start(){
		parent = GameObject.Find ("Defenders");
		if(!parent){
			parent = new GameObject("Defenders");
		}

		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		int defenderCost = Button.selectedDefender.GetComponent<Defender> ().starCost;

		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			GameObject defender = Instantiate (Button.selectedDefender, roundedPos, Quaternion.identity);
			defender.transform.parent = parent.transform;
		} else {
			Debug.Log ("Not enough stars");
		}
	}

	Vector2 SnapToGrid(Vector2 rawWorldPoint){
		float newX = Mathf.RoundToInt(rawWorldPoint.x);
		float newY = Mathf.RoundToInt(rawWorldPoint.y);

		return new Vector2(newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
	
		Vector3 vector3position = new Vector3(mouseX, mouseY, 10f);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(vector3position);

 		return worldPos;
	}
}
