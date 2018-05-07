using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour {
	public GameObject itemBox;
	Animator animBox;
	Animator animButton;
	bool trigger = false;
	// Use this for initialization
	void Start () {
		animButton = GetComponent<Animator> ();	
		animBox = itemBox.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TriggerItemBox() {
		trigger = !trigger;
		animButton.SetBool ("isBoxTriggered", trigger);
		animBox.SetBool ("isBoxTriggered", trigger);
	}
}
