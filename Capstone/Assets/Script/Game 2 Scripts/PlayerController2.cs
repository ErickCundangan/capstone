using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
	public static PlayerController2 Instance { set; get; }
	float distance = 10;
	public int playerHealth = 5;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float maxBound, minBound;
	private float nextFire;

	void Start() {
		Instance = this;
		Screen.orientation = ScreenOrientation.Portrait;
	}

	void Update() {
		if (GameOver.Instance.isPlayerDead)
			return;
		
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (playerHealth <= 0) {
			GameOver.Instance.isPlayerDead = true;
		}
	}

	void OnMouseDrag() {
		if (Time.timeScale == 0)
			return;

		if (GameOver.Instance.isPlayerDead)
			return;
		
		float h = 0;


		Vector3 touchPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 playerPos = Camera.main.ScreenToWorldPoint (touchPos);

		if (playerPos.x > maxBound)
			h = maxBound;
		else if (playerPos.x < minBound)
			h = minBound;
		else
			h = playerPos.x;
		
		transform.position = new Vector3 (h, -6.5f, 0);
	}
}
