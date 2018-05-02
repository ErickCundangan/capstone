using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class BossController : MonoBehaviour {
	public static BossController Instance { set; get; }
	private Transform boss;
	private Animator anim;
	public GameObject shot;
	public float fireRate;
	public float speed;
	public float bossHealth = 10;
	public bool hasBossAppeared = false;
	// Use this for initialization
	void Start () {
		Instance = this;
		boss = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if (anim != null) {
			anim.SetBool ("isBossShooting", false);
		}

		if (boss.position.y >= 4 && EnemyController.Instance.enemyHolder.childCount == 0)
			boss.position += Vector3.down * speed;
		
		else if (boss.position.y <= 4) {
			if (anim.GetBool ("isBossDead"))
				boss.position += Vector3.zero;

			else
				boss.position += Vector3.right * speed;

			if (boss.position.x < -5 || boss.position.x > 5) {
				speed = -speed;
				return;
			}
		}

		if (UnityEngine.Random.value > fireRate && !anim.GetBool ("isBossDead") && boss.position.y <= 4) {
			Instantiate (shot, new Vector3(boss.position.x, boss.position.y - 2.75f, boss.position.z), boss.rotation);
			if (anim != null)
				anim.SetBool ("isBossShooting", true);
		}

		if (BossController.Instance.bossHealth <= 0) {
			//Destroy (other.gameObject);
			string sceneName = SceneManager.GetActiveScene().name;
			char[] gameStage = sceneName.Where (char.IsDigit).ToArray ();

			if (anim != null) {
				anim.SetBool ("isBossDead", true); 
			}

			SaveManager.Instance.completeStage (gameStage[0] - '0', gameStage[1] - '0' - 1);
			SaveManager.Instance.Save ();
		}
	}

	void DestroyEnemy() {
		Destroy (gameObject);
		StageClear.Instance.isStageComplete = true;
	}
}
