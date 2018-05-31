using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionSystem : MonoBehaviour {
	public Slider bgm;
	public Slider sfx;
	public GameObject options;

	List<AudioSource> audioList;
	AudioSource bgmAudio;
	int volume = 0;

	bool isOptionsActive = false;

	// Use this for initialization
	void Start () {
		audioList = new List<AudioSource>(Resources.FindObjectsOfTypeAll<AudioSource> ());
		for (int i = 0; i < audioList.Count; i ++) {
			if (audioList[i].gameObject.tag == "MainCamera") {
				bgmAudio = audioList[i];
				audioList.Remove (audioList[i]);
			}
		}

		bgm.value = SaveManager.Instance.GetSound () [0];
		sfx.value = SaveManager.Instance.GetSound () [1];

		options.SetActive (false);
		isOptionsActive = false;
	}

	// Update is called once per frame
	void Update () {
		bgmAudio.volume = bgm.value;

		foreach (AudioSource audio in audioList) {
			audio.volume = sfx.value;
		}

		SaveManager.Instance.SetSound (bgm.value, sfx.value);
		SaveManager.Instance.Save (SaveManager.Instance.currentUser);
	}

	public void TurnOnSound() {
		volume = 1;
		//SaveManager.Instance.SetSound (true);
		SaveManager.Instance.Save (SaveManager.Instance.currentUser);
	}

	public void TurnOffSound() {
		volume = 0;
		//SaveManager.Instance.SetSound (false);
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
