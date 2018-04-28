using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public GameObject player;
	public GameObject gameOverPanel;
	public static bool isPlayerDead = false;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = player.GetComponent<Animator> ();
		gameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerDead) {
			anim.SetBool ("isPlayerDead", isPlayerDead);
			gameOverPanel.SetActive (true);
		}
	}

	void stopTime() {
		Time.timeScale = 0;
	}
}
