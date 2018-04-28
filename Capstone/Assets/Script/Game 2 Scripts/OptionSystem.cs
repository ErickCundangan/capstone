using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSystem : MonoBehaviour {
	public GameObject options;
	bool isOptionsActive = false;

	// Use this for initialization
	void Start () {
		options.SetActive (false);
		isOptionsActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CogButton_onClick() {
		if (GameOver.isPlayerDead || StageClear.isStageComplete)
			return;
		
		if (!isOptionsActive) {
			options.SetActive (true);
			isOptionsActive = true;
			Time.timeScale = 0;
		} else {
			options.SetActive (false);
			isOptionsActive = false;
			Time.timeScale = 1;
		}
	}

	public void Resume_onClick() {
		options.SetActive (false);
		isOptionsActive = false;
		Time.timeScale = 1;
	}

	public void Restart_onClick() {
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);		
	}
}
