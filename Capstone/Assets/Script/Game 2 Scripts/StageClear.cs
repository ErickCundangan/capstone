using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour {
	public GameObject stageClearPanel;
	public static bool isStageComplete = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		stageClearPanel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (isStageComplete) {
			stageClearPanel.SetActive (true);
		}
	}
}
