using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {
	public float speed;
	Transform powerUp;
	// Use this for initialization
	void Start () {
		powerUp = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		powerUp.position += Vector3.down * speed;

		if (powerUp.position.y <= -10) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player" && !StageClear.Instance.isStageComplete) {
			if (gameObject.tag == "Heart") {
				if (PlayerController2.Instance.playerHealth < 5 && PlayerController2.Instance.playerHealth > 0)
					PlayerController2.Instance.playerHealth += 1;

			} else if (gameObject.tag == "FireUp") {
				if (!PowerUpManager.Instance.isFireUpActivated) {
					PowerUpManager.Instance.isFireUpActivated = true;
					PlayerController2.Instance.fireRate = 0.3f;
				}
			}
			Destroy (gameObject);
		}
	}
}
