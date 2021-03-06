using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour {
	private Animator anim;
	public float speed;
	public GameObject shot;
	public float fireRate = 0.997f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	bool m1 = false;
	bool m2 = false;

	void FixedUpdate() {
		anim.SetBool ("isEnemyShooting", false);

		if (gameObject.GetComponent<Animator> ().GetBool ("isEnemyDead")) {
			gameObject.transform.position += Vector3.zero;
			return;
		}

		if (!m1 && gameObject.transform.position.x <= 2) {
			gameObject.transform.position += Vector3.right * speed;
			if (gameObject.transform.position.x >= 2)
				m1 = true;
		}

		if (m1 && !m2 && gameObject.transform.position.y <= 6) {
			if (gameObject.transform.position.y <= 5)
				gameObject.transform.position += new Vector3 (0.3f, 1f, 0f) * speed;

			if (gameObject.transform.position.y >= 5)
				gameObject.transform.position += new Vector3 (-0.3f, 1f, 0f) * speed;
			
			if (gameObject.transform.position.y >= 6)
				m2 = true;
		}

		if (!gameObject.GetComponent<Animator> ().GetBool ("isEnemyDead") && m2)
			gameObject.transform.position += Vector3.left * speed;

		if ((gameObject.transform.position.x < -5 || gameObject.transform.position.x > 5) && m2) {
			speed = -speed;
		}

		if (Random.value > fireRate && !gameObject.GetComponent<Animator> ().GetBool ("isEnemyDead")) {
			Instantiate (shot, gameObject.transform.position, gameObject.transform.rotation);
			anim.SetBool ("isEnemyShooting", true);
		}

		if (gameObject.transform.position.y <= -6.5) {
			GameOver.Instance.isPlayerDead = true;
			Time.timeScale = 0;
		}
	}

}
