using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
	public GameObject game1;
	Button[] game1Stages;
	public GameObject game2;
	Button[] game2Stages;
	public GameObject game3;
	Button[] game3Stages;

	// Use this for initialization
	void Start () {
		game1Stages = game1.GetComponentsInChildren<Button> ();
		game2Stages = game2.GetComponentsInChildren<Button> ();
		game3Stages = game3.GetComponentsInChildren<Button> ();

		foreach (Button stage in game1Stages) {
			stage.interactable = false;
		}
		foreach (Button stage in game2Stages) {
			stage.interactable = false;
		}

		foreach (Button stage in game3Stages) {
			stage.interactable = false;
		}

		game1Stages [0].interactable = true;

		if (SaveManager.Instance.isStageCleared (1, 0))
			game1Stages [1].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (1, 1))
			game1Stages [2].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (1, 2))
			game2Stages [0].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (2, 0))
			game2Stages [1].interactable = true;

		if (SaveManager.Instance.isStageCleared (2, 1))
			game2Stages [2].interactable = true;

		if (SaveManager.Instance.isStageCleared (2, 2))
			game2Stages [3].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (2, 3))
			game3Stages [0].interactable = true;

		if (SaveManager.Instance.isStageCleared (3, 0))
			game3Stages [1].interactable = true;

		if (SaveManager.Instance.isStageCleared (3, 1))
			game3Stages [2].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (3, 2))
			game3Stages [3].interactable = true;

		//if (SaveManager.Instance.isStageCleared (3, 3))
			//game4Stages [0].interactable = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
