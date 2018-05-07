using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthSystem : MonoBehaviour {
	public GameObject health;
	public GameObject boss;
	BossController bossCtrlr;
	Slider bossHealth;
	// Use this for initialization
	void Start () {
		bossCtrlr = boss.GetComponent<BossController> ();
		bossHealth = health.GetComponent<Slider> ();
		bossHealth.maxValue = bossCtrlr.bossHealth;
		bossHealth.value = bossCtrlr.bossHealth;
		InvokeRepeating ("ActivateHealthBar", 0.1f, 0.1f);
		health.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		bossHealth.value = bossCtrlr.bossHealth;
	}

	void ActivateHealthBar() {
		if (BossController.Instance.hasBossAppeared) {
			health.SetActive (true);
		}

		bossHealth.value = bossCtrlr.bossHealth;
	}
}
