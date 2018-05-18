using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccountLoader : MonoBehaviour {
	public GameObject newGameBox;
	public GameObject loadGameBox;
	public GameObject errorHolder;
	public InputField unameNew;
	public InputField passNew;
	public InputField unameLoad;
	public InputField passLoad;

	Text error;
	// Use this for initialization
	void Start () {
		passNew.inputType = InputField.InputType.Password;
		passLoad.inputType = InputField.InputType.Password;
		error = errorHolder.GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewAccSumbit_OnClick() {
		string uname = unameNew.text;
		string pass = passNew.text;

		if (uname.Length < 8) {
			error.text = "Username must be at least 8 characters.";
			errorHolder.SetActive (true);
			StartCoroutine (Wait ());
			return;
		}

		if (pass.Length < 8) {
			error.text = "Password must be at least 8 characters.";
			errorHolder.SetActive (true);
			StartCoroutine (Wait ());
			return;
		}

		if (SaveManager.Instance.NewGame (uname, pass))
			LoadingScreenControl.Instance.LoadScene ("Quiz");
		else {
			error.text = "Username already exists!";
			errorHolder.SetActive (true);
			StartCoroutine (Wait());
		}
	}

	public void LoadAccSumbit_OnClick() {
		string uname = unameLoad.text;
		string pass = passLoad.text;
		if (SaveManager.Instance.Load (uname, pass)) {
			if (!SaveManager.Instance.state.isPreQuizDone)
				LoadingScreenControl.Instance.LoadScene ("Quiz");
			else
				LoadingScreenControl.Instance.LoadScene ("Main");
		} else {
			error.text = "Invalid Username/Password!";
			errorHolder.SetActive (true);
			StartCoroutine (Wait());
		}
	}

	public void NewGame_OnClick() {
		loadGameBox.SetActive (false);
		newGameBox.SetActive (true);
	}

	public void Continue_OnClick() {
		newGameBox.SetActive (false);
		loadGameBox.SetActive (true);
	}

	public void Close_OnClick() {
		newGameBox.SetActive (false);
		loadGameBox.SetActive (false);
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds (3f);
		errorHolder.SetActive (false);
	}
}
