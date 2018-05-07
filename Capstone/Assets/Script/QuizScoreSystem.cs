using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScoreSystem : MonoBehaviour {
	public GameObject quizScoreBox;
	public Text quiz1;
	public Text quiz2;

	// Use this for initialization
	void Start () {
		quiz1.text = SaveManager.Instance.state.preQuizScore.ToString () + "/50";
		quiz2.text = SaveManager.Instance.state.postQuizScore.ToString () + "/50";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowScores_OnClick() {
		quizScoreBox.SetActive (true);
		Time.timeScale = 0;
	}

	public void HideScores_OnClick() {
		quizScoreBox.SetActive (false);
		Time.timeScale = 1;
	}
}
