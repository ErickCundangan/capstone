using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
	private Transform player;
	float distance = 10;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float maxBound, minBound;
	private float nextFire;

	void Start() {
		Screen.orientation = ScreenOrientation.Portrait;
		player = GetComponent<Transform> ();
	}

	void Update() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void OnMouseDrag() {
		float h = 0;

		if (GameOver.isPlayerDead)
			return;

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
