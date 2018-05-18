using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {
	Animator anim;
	bool isSceneLoading = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnClick() {
		if (!isSceneLoading) {
			isSceneLoading = true;
			anim.SetBool ("isScreenTapped", true);
			StartCoroutine (Load ());
		}
	}

	IEnumerator Load() {
		yield return new WaitForSeconds (1f);
		LoadingScreenControl.Instance.LoadScene ("Main");
	}
}
