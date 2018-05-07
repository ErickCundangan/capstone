using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnDragControl : MonoBehaviour {
	public GameObject player;
	public int maxBound, minBound;
	float distance = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

		player.transform.position = new Vector3 (h, -6.5f, 0);
	}
}
