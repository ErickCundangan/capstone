using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
	public GameObject enemyHolder;
	public GameObject warning;
	public int respawnCount;
	private bool bossSpawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyController.Instance.enemyHolder.childCount == 0 && respawnCount >= 0) {
			respawnCount -= 1;
			if (respawnCount == -1 && !bossSpawned) {
				BossController.Instance.hasBossAppeared = true;
				Instantiate (warning, Vector3.zero, Quaternion.identity);
				bossSpawned = true;
			} else {
				Destroy (EnemyController.Instance.enemyHolder.gameObject);
				Instantiate (enemyHolder, new Vector3 (-5, 14, 0), Quaternion.identity);
			}
		}
	}
}
