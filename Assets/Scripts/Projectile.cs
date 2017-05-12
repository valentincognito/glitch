using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed = 1f;
	public float damage = 25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;

		if(!obj.GetComponent<Attacker>()){
			return;
		}

		// here I could handle an hit animation

		Health health = collider.GetComponent<Health> ();
		if(health)health.DealDamage (damage);

		Destroy (gameObject);

	}
}
