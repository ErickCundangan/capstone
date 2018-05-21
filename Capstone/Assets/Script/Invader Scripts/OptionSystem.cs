using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSystem : MonoBehaviour {
	public GameObject options;
	public AudioListener audioListener;

	List<AudioSource> audioList;
	int volume = 0;

	bool isOptionsActive = false;

	// Use this for initialization
	void Start () {
		audioList = new List<AudioSource>(Resources.FindObjectsOfTypeAll<AudioSource> ());
		options.SetActive (false);
		isOptionsActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (SaveManager.Instance.state.sound)
			volume = 1;
		else
			volume = 0;
		
		foreach (AudioSource audio in audioList) {
			audio.volume = volume;
		}
	}

	public void TurnOnSound() {
		volume = 1;
		SaveManager.Instance.SetSound (true);
		SaveManager.Instance.Save (SaveManager.Instance.currentUser);
	}

	public void TurnOffSound() {
		volume = 0;
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
