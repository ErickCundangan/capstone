using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAnimation : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	Transform transform;
	float y;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		transform = GetComponent<Transform> ();
		y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= y + 1) {
			gameObject.SetActive (false);
			return;
		}

		transform.position += Vector3.up * 0.02f;

	}
}
