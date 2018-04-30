using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

	public GameObject game2;
	Button[] game2Stages;

	// Use this for initialization
	void Start () {
		game2Stages = game2.GetComponentsInChildren<Button> ();

		foreach (Button stage in game2Stages) {
			stage.enabled = false;
		}

		if (SaveManager.Instance.state.gameOneStagesCleared == 7) {
			for (int i = 0; i <= SaveManager.Instance.state.gameTwoStagesCleared; i++) {
				game2Stages [i].enabled = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
