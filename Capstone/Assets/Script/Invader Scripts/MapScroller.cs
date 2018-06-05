using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroller : MonoBehaviour {
	public float speed;
	Vector3 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime);

		if (transform.position.y < -26.33)
			transform.position = startPos;
	}
}
