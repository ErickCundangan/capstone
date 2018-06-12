using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour {
	public static PlayerController2 Instance { set; get; }
	float distance = 10;
	public int playerHealth = 5;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float maxBound, minBound;
	private float nextFire;
	private float nextFire2;
	public Text timeCounter;
	public float timeLeft;
	private float minutes;
	private float seconds;
	public bool stopTime = false;

	void Start() {
		Instance = this;
		Screen.orientation = ScreenOrientation.Portrait;
	}

	void Update() {
		if (!stopTime) {
			if (timeLeft <= 0) {
				stopTime = true;
				GameOver.Instance.isPlayerDead = true;
				return;
			}

			if (GameOver.Instance.isPlayerDead)
				return;
		
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				if (SceneManager.GetActiveScene ().name.Equals ("Game2_Stage4")) {
					Instantiate (shot, new Vector3 (shotSpawn.position.x - 0.2f, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
					Instantiate (shot, new Vector3 (shotSpawn.position.x + 0.2f, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
				
				} else {
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}
			}

			if (playerHealth <= 0) {
				GameOver.Instance.isPlayerDead = true;
			}

			timeLeft -= Time.deltaTime;
			minutes = Mathf.Floor (timeLeft / 60);

			seconds = timeLeft % 60;

			timeCounter.text = string.Format ("Time: {0:0}:{1:00}", minutes, seconds);
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
