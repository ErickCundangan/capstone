using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	private Transform bullet;
	private Animator anim;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		bullet.position += Vector3.up * speed;

		if (bullet.position.y >= 10) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy") {
			anim = other.gameObject.GetComponent<Animator> ();	
			if (anim != null)
				anim.SetBool ("isEnemyDead", true);
			Destroy (gameObject);
		}

		if (other.tag == "Boss") {
			BossController.bossHealth -= 1;
			Destroy (gameObject);

			if (BossController.bossHealth == 0)
				Destroy (other.gameObject);
		}
	}
}
