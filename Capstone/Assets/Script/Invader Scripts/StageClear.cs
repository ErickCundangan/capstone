using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour {
	public static StageClear Instance { set; get; }
	public GameObject stageClearPanel;
	public GameObject buttons;
	public bool isStageComplete = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		Instance = this;
		buttons.SetActive (false);
		stageClearPanel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (isStageComplete) {
			buttons.SetActive (true);
			stageClearPanel.SetActive (true);
		}
	}
}
