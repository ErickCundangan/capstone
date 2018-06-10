using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager Instance { set; get; }

	public int currentScore;
	public int threeStarScore;
	public int twoStarScore;
	public int oneStarScore;
	public int bossScore;

	int totalScore;
	int healthScore;
	int timeScore;

	public Text runningScore;
	public Text textScores;
	public Image stars;
	public Sprite[] starSprites;
	public Text text3star;
	public Text text2star;
	public Text text1star;
	// Use this for initialization
	void Start () {
		Instance = this;
		text3star.text = "Score > " + threeStarScore;
		text2star.text = "Score > " + twoStarScore;
		text1star.text = "Score > " + oneStarScore;
	}

	bool flag = false;

	// Update is called once per frame
	void Update () {
		runningScore.text = "Score: " + currentScore;
		if (StageClear.Instance.isStageComplete && !flag) {
			int star = 0;
			healthScore = PlayerController2.Instance.playerHealth * 200;
			timeScore = (int) Mathf.Floor (PlayerController2.Instance.timeLeft) * 50;
			totalScore = currentScore + healthScore + timeScore + bossScore;
			textScores.text = currentScore + "\n" + bossScore + "\n" + healthScore + "\n" + timeScore + "\n" + totalScore;

			if (totalScore >= threeStarScore) {
				stars.sprite = starSprites [0];
				star = 3;
			} else if (totalScore >= twoStarScore && totalScore < threeStarScore) {
				stars.sprite = starSprites [1];
				star = 2;
			} else if (totalScore >= oneStarScore && totalScore < twoStarScore) {
				stars.sprite = starSprites [2];
				star = 1;
			}

			string sceneName = SceneManager.GetActiveScene().name;
			char[] gameStage = sceneName.Where (char.IsDigit).ToArray ();

			if (SaveManager.Instance.GetScore (gameStage [0] - '0', gameStage [1] - '0') < star) {
				SaveManager.Instance.SetHighScore (gameStage [0] - '0', gameStage [1] - '0', star);
				SaveManager.Instance.Save (SaveManager.Instance.currentUser);
			}
			flag = true;
		}
	}
}
