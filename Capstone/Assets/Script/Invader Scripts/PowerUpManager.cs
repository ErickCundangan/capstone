using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
	public static PowerUpManager Instance { set; get; }
	public GameObject healthUp;
	public GameObject fireRateUp;
	public float powerUpRate;
	public GameObject[] powerUp;
	public bool isFireUpActivated = false;
	float FireUpDuration = 3f;
	float dtime = 0f;

	// Use this for initialization
	void Start () {
		Instance = this;
		powerUp = new GameObject[] { healthUp, fireRateUp };
	}

	// Update is called once per frame
	void Update () {
		if (Random.value > powerUpRate && Time.timeScale != 0) {
			System.Random rnd = new System.Random ();
			Instantiate (powerUp [rnd.Next (0, 2)], new Vector3 (rnd.Next (-5, 6), 14, 0), new Quaternion (0, 0, 0, 0));
		}

		if (isFireUpActivated) {
			dtime += Time.deltaTime;

			if (dtime >= FireUpDuration) {
				PlayerController2.Instance.fireRate = 0.6f;
				isFireUpActivated = false;
				dtime = 0f;
			}
		}
	}
}
