using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	public GameObject stage;

	void ShowStageSelection() {
		stage.SetActive (true);
	}
}
