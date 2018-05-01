using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
	public GameObject enemyHolder;
	public int spawnCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyController.Instance.enemyHolder.childCount == 0 && spawnCount != 0) {
			Destroy (EnemyController.Instance.enemyHolder.gameObject);
			Instantiate (enemyHolder, new Vector3 (-5, 14, 0), Quaternion.identity);
			spawnCount -= 1;
		}
	}
}
