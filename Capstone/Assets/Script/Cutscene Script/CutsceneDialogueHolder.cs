using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutsceneDialogueHolder : MonoBehaviour {
	public  string dialogueSpeaker;
	public  string[] dialogueLines;
	public  Sprite dialogueSprite;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void StartAnim() {
		try {
			anim.SetBool ("startAnim", true);
		}

		catch {
		}
	}
}
