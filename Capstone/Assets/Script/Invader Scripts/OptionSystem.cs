using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSystem : MonoBehaviour {
	public GameObject options;
	public AudioListener audioListener;
	bool isOptionsActive = false;

	// Use this for initialization
	void Start () {
		options.SetActive (false);
		isOptionsActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOnSound() {
		audioListener.enabled = true;
		SaveManager.Instance.SetSound (true);
		SaveManager.Instance.Save (SaveManager.Instance.currentUser);
	}

	public void TurnOffSound() {
		audioListener.enabled = false;
		SaveManager.Instance.SetSound (false);
		SaveManager.Instance.Save (SaveManager.Instance.currentUser);
	}

	public void CogButton_onClick() {
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

	public void GoToMainMenu_onClick() {
		SceneManager.LoadScene ("Main");
		Time.timeScale = 1;
	}

	public void GoToHome_onClick() {
		SceneManager.LoadScene ("Home");
		Time.timeScale = 1;
	}


}
