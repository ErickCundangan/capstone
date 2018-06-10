using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilipinoSoldierController : MonoBehaviour {
	private Animator anim;
	public GameObject shot;
	public float fireRate = 0.999f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate() {
		anim.SetBool ("isShooting", false);

		if (Random.value > fireRate && !gameObject.GetComponent<Animator> ().GetBool ("isDead")) {
			Instantiate (shot, gameObject.transform.position, gameObject.transform.rotation);
			anim.SetBool ("isShooting", true);
		}

		if (gameObject.transform.position.y <= -6.5) {
			GameOver.Instance.isPlayerDead = true;
			Time.timeScale = 0;
		}
	}
}
