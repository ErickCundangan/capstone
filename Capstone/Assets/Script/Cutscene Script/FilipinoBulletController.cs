using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilipinoBulletController : MonoBehaviour {
	private Transform bullet;
	private Animator anim;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		bullet.position += Vector3.up * speed;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy") {
			anim = other.gameObject.GetComponent<Animator> ();
			if (anim != null) {
				if (!anim.GetBool ("isEnemyDead")) {
					anim.SetBool ("isEnemyDead", true);
					Destroy (gameObject);
				}
			}
		}
	}
}
