using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public static EnemyManager Instance { set; get; }
	public GameObject[] spawn;
	public GameObject warning;
	bool bossSpawned = false;
	int i = 0;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("EnemyHolder").transform.childCount == 0 && !bossSpawned) {
			if (i >= spawn.Length && !bossSpawned) {
				BossController.Instance.hasBossAppeared = true;
				Instantiate (warning, Vector3.zero, Quaternion.identity);
				bossSpawned = true;
			} else {
				Destroy (GameObject.FindGameObjectWithTag ("EnemyHolder"));
				Instantiate (spawn[i], Vector3.zero, Quaternion.identity);
				i++;
			}
		}
	}
}
