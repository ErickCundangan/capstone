using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager Instance { set; get; }

	public int threeStarScore;
	public int twoStarScore;
	public int oneStarScore;
	public int bossScore;

	int totalScore;
	int currentScore;
	int healthScore;
	int timeScore;

	public Text textScores;
	public Image stars;
	public Sprite[] starSprites;

	// Use this for initialization
	void Start () {
		Instance = this;
	}

	bool flag = false;

	// Update is called once per frame
	void Update () {
		if (StageClear.Instance.isStageComplete && !flag) {
			healthScore = PlayerController2.Instance.playerHealth * 200;
			timeScore = (int) Mathf.Floor (PlayerController2.Instance.timeLeft) * 50;
			totalScore = currentScore + healthScore + timeScore + bossScore;
			textScores.text = currentScore + "\n" + bossScore + "\n" + healthScore + "\n" + timeScore + "\n" + totalScore;

			if (totalScore >= threeStarScore)
				stars.sprite = starSprites [0];

			else if (totalScore >= twoStarScore && totalScore < threeStarScore)
				stars.sprite = starSprites [1];

			else if (totalScore >= oneStarScore && totalScore < twoStarScore)
				stars.sprite = starSprites [2];
			
			flag = true;
		}
	}
}
