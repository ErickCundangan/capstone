using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {
	public static LoadingScreenControl Instance {set;get;}
	public GameObject loadingScreen;
	AsyncOperation async;

	void Start() {
		Instance = this;
	}

	public void LoadScene(string scene) {
		StartCoroutine (LoadingScreen (scene));
	}

	IEnumerator LoadingScreen(string scene) {
		loadingScreen.SetActive (true);
		async = SceneManager.LoadSceneAsync (scene);
		async.allowSceneActivation = false;

		while (async.isDone == false) {
			if (async.progress == 0.9f)
				async.allowSceneActivation = true;

			yield return null;
		}
	}
}
