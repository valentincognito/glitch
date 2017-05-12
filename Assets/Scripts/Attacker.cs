using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {


	[Range(-1f, 1.5f)] private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		if(!currentTarget){
			animator.SetBool ("isAttacking", false);
		}
	}
		

	public void setSpeed(float speed){
		currentSpeed = speed;
	}

	// Call from the animator
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health> ();
			if(health)health.DealDamage (damage);
		}
	}

	public void Attack(GameObject obj){
		currentTarget = obj;

	}

}
