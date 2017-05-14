using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


	public GameObject[] attackersPrefabArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackersPrefabArray){
			if(isTimeToSpawn(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}

	private void Spawn(GameObject obj){
		GameObject attacker = Instantiate(obj, new Vector3(2f, 4f, 0f), Quaternion.identity) as GameObject;
		attacker.transform.parent = this.transform;
		attacker.transform.position = this.transform.position;
	}

	private bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		float treshhold = spawnsPerSecond * Time.deltaTime / 5;

		return Random.value < treshhold;
	}

}
