using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public static GameOver Instance { set; get; }
	public GameObject player;
	public GameObject gameOverPanel;
	public GameObject buttons;
	public bool isPlayerDead = false;
	private Animator anim;
	// Use this for initialization
	void Start () {
		Instance = this;
		anim = player.GetComponent<Animator> ();
		gameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerDead) {
			anim.SetBool ("isPlayerDead", isPlayerDead);
			gameOverPanel.SetActive (true);
			buttons.SetActive (true);
		}
	}

	void stopTime() {
		Time.timeScale = 0;
	}
}
