using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
	private Transform boss;
	public GameObject shot;
	public float fireRate;
	public float speed;
	public static float bossHealth = 10;
	// Use this for initialization
	void Start () {
		boss = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		if (boss.position.y >= 4)
			boss.position += Vector3.down * speed;
		else {
			boss.position += Vector3.right * speed;
			if (boss.position.x < -5 || boss.position.x > 5) {
				speed = -speed;
				return;
			}

			if (Random.value > fireRate) {
				Instantiate (shot, new Vector3(boss.position.x, boss.position.y - 2.75f, boss.position.z), boss.rotation);
			}
		}
	}
}
