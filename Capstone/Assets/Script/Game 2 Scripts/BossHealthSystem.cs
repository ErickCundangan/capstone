using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthSystem : MonoBehaviour {

	Slider bossHealth;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
		InvokeRepeating ("ActivateHealthBar", 0.1f, 0.1f);
		bossHealth = GetComponent<Slider> ();
		bossHealth.maxValue = BossController.bossHealth;
		bossHealth.value = BossController.bossHealth;
	}
	
	// Update is called once per frame
	void Update () {
		bossHealth.value = BossController.bossHealth;
	}

	void ActivateHealthBar() {
		if (BossController.hasBossAppeared) {
			gameObject.SetActive (true);
			CancelInvoke ();
		}
	}
}
