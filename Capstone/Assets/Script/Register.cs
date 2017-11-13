using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	public GameObject confPassword;
	private string Username;
	private string Password;
	private string ConfPassword;
	private string form;

	// Use this for initialization
	void Start () {
		
	}
	public void RegisterButton(){
		print ("Registration Successful");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
			if (password.GetComponent<InputField> ().isFocused) {
				confPassword.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Password != "" && ConfPassword != "") {
				RegisterButton ();
			}
			Username = username.GetComponent<InputField> ().text;
			Password = password.GetComponent<InputField> ().text;
			ConfPassword = confPassword.GetComponent<InputField> ().text;
		}
	}
}
