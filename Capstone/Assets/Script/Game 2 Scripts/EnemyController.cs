using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform enemyHolder;
	private Animator[] anims;
	public float speed;
	public GameObject shot;
	public GameObject boss;
	public GameObject warning;
	public float fireRate = 0.5f;
	private bool bossSpawned = false;

	// Use this for initialization
	void Start () {
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
				return;
			}

			if (Random.value > fireRate && !enemy.gameObject.GetComponent<Animator> ().GetBool ("isEnemyDead")) {
				Instantiate (shot, enemy.position, enemy.rotation);
				foreach(Animator anim in anims)
					if (anim != null)
						anim.SetBool ("isEnemyShooting", true);
			}

			if (enemy.position.y <= -6.5) {
				GameOver.isPlayerDead = true;
				Time.timeScale = 0;
			}
		}

		if (enemyHolder.childCount == 0) {
			if (!bossSpawned) {
				BossController.hasBossAppeared = true;
				Instantiate (warning, Vector3.zero, new Quaternion (0, 0, 0, 0));	
				Instantiate (boss, new Vector3 (0, 14, 0), new Quaternion (0, 0, 0, 0));
				bossSpawned = true;
			}
		}
	}
}
