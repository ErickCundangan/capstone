using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager Instance { set; get; }
	public float currentScore;
	public int threeStarScore;
	public int twoStarScore;
	public int oneStarScore;

	// Use this for initialization
	void Start () {
		Instance = this;
		InvokeRepeating ("TallyScore", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TallyScore() {
		if (StageClear.Instance.isStageComplete) {
			currentScore += (PlayerController2.Instance.playerHealth * 100) + (Mathf.Floor(PlayerController2.Instance.timeLeft * 50));
			CancelInvoke ();
		}
	}
}
