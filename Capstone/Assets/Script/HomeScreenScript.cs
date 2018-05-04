using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
	}

	public void ExitGame() {
		Application.Quit ();
	}
}
