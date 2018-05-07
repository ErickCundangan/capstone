using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public static EnemyController Instance { set; get; }
	public Transform enemyHolder;
	private Animator[] anims;
	public float speed;
	public GameObject shot;
	public GameObject boss;
	public float fireRate = 0.5f;

	// Use this for initialization
	void Start () {
		Instance = this;
		enemyHolder = GetComponent<Transform> ();
		anims = GetComponentsInChildren<Animator> ();
		
	}

	void FixedUpdate() {
		foreach (Animator anim in anims)
			if (anim != null)
				anim.SetBool ("isEnemyShooting", false);

		foreach (Transform enemy in enemyHolder) {
			if (enemy.gameObject.GetComponent<Animator> ().GetBool ("isEnemyDead") || enemyHolder.position.y > 7)
				enemy.position += Vector3.zero;

			else
				enemy.position += Vector3.right * speed;
			
			if (enemy.position.x < -5 || enemy.position.x > 5) {
				speed = -speed;
			}

			if (Random.value > fireRate/* && !enemy.gameObject.GetComponent<Animator> ().GetBool ("isEnemyDead") && enemyHolder.position.y <= 7*/) {
				Instantiate (shot, enemy.position, enemy.rotation);
				foreach(Animator anim in anims)
					if (anim != null)
						anim.SetBool ("isEnemyShooting", true);
			}

			if (enemy.position.y <= -6.5) {
				GameOver.Instance.isPlayerDead = true;
				Time.timeScale = 0;
			}
		}
	}
}
