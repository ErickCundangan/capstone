using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmericanBulletController : MonoBehaviour {
	private Transform bullet;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		bullet.position += Vector3.up * -speed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Animator anim = other.gameObject.GetComponent<Animator> ();
			if (anim != null) {
				if (!anim.GetBool ("isDead")) {
					anim.SetBool ("isDead", true);
					Destroy (gameObject);
				}
			}
		}
	}
}
