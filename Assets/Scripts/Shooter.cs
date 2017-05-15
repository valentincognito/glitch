using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent; 
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){

		animator = GetComponent<Animator> ();

		projectileParent = GameObject.Find ("Projectiles");
	
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update(){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach(Spawner spawner in spawnerArray){
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			} else {
				Debug.LogError ("No lane spawner found");
			}
		}
	}

	private bool IsAttackerAheadInLane (){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		} 
		foreach(Transform child in myLaneSpawner.transform){
			if (child.transform.position.x > transform.position.x) {
				return true;
			}
		}
		return false;
	}

	private void Fire(){

		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;

	}
		
}
