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
			stage.interactable = false;
		}

		if (SaveManager.Instance.isStageCleared (1, 2))
			game2Stages [0].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (2, 0))
			game2Stages [1].interactable = true;

		if (SaveManager.Instance.isStageCleared (2, 1))
			game2Stages [2].interactable = true;

		if (SaveManager.Instance.isStageCleared (2, 2))
			game2Stages [3].interactable = true;
		
		//if (SaveManager.Instance.isStageCleared (2, 3))
			//game3Stages [0].IsInteractable = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
