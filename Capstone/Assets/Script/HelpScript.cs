using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour {

	public GameObject tutorial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenHelp_OnClick() {
		tutorial.SetActive (true);
		Time.timeScale = 0;
	}

	public void CloseHelp_OnClick() {
		tutorial.SetActive (false);
		Time.timeScale = 1;
	}
}
