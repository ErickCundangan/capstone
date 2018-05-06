using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
	public GameObject tutorial;

	// Use this for initialization
	void Start () {
		StartCoroutine (Wait ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Wait () {
		yield return new WaitForSeconds (1f);
		tutorial.SetActive (true);
		Time.timeScale = 0;
	}

	public void TapAnywhereToContinue() {
		tutorial.SetActive (false);
		Time.timeScale = 1;
	}
}
