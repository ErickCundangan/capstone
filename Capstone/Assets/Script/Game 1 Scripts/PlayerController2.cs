using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
	float distance = 10;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Start() {

	}

	void Update() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void OnMouseDrag() {
		Vector3 touchPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 playerPos = Camera.main.ScreenToWorldPoint (touchPos);
		transform.position = new Vector3 (playerPos.x, -3, 0);
	}
}
