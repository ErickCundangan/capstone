using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuizManager : MonoBehaviour {
	public static QuizManager Instance { set; get; }
	public GameObject scoreObject;
	Text scoreText;
	public Text questionNo;
	public Text question;
	public Text ansA;
	public Text ansB;
	public Text ansC;
	public Text ansD;

	public string[] questions;
	public string[] answerA;
	public string[] answerB;
	public string[] answerC;
	public string[] answerD;
	public int[] answer;

	public Text timeCounter;
	public float timeLeft;
	private float minutes;
	private float seconds;
	public bool stopTime = false;

	int score = 0;
	int noOfQuestions = 0;
	int i = 0;
	List<int> exclude = new List<int>();

	// Use this for initialization
	void Start () {
		Instance = this;
		LoadQuestion ();
	}

	void Update() {
		if (!stopTime)
		{
			if (timeLeft <= 0)
			{
				stopTime = true;
				scoreText = scoreObject.GetComponent<Text> ();
				scoreText.text = score.ToString () + "/50";

				if (!SaveManager.Instance.state.isPreQuizDone) {
					SaveManager.Instance.SetPreQuizScore (score);
					SaveManager.Instance.Save (SaveManager.Instance.currentUser);
					gameObject.SetActive (false);
				} else {
					SaveManager.Instance.SetPostQuizScore (score);
					SaveManager.Instance.Save (SaveManager.Instance.currentUser);
					gameObject.SetActive (false);
				}

				return;
			}

			timeLeft -= Time.deltaTime;
			minutes = Mathf.Floor(timeLeft / 60);
			seconds = timeLeft % 60;

			timeCounter.text = string.Format("Time: {0:0}:{1:00}", minutes, seconds);
		}
	}

	void LoadQuestion() {
		noOfQuestions++;
		i = GetRandomNum ();
		exclude.Add (i);
		questionNo.text = "Question # " + noOfQuestions.ToString();
		question.text = questions [i];
		ansA.text = answerA [i];
		ansB.text = answerB [i];
		ansC.text = answerC [i];
		ansD.text = answerD [i];

	}

	public void AnsA_OnClick() {
		if (answer [i] == 1) {
			score++;
		} else {
		}

		CheckQuestions ();
	}

	public void AnsB_OnClick() {
		if (answer [i] == 2) {
			score++;
		} else {
		}

		CheckQuestions ();
	}

	public void AnsC_OnClick() {
		if (answer [i] == 3) {
			score++;
		} else {
		}

		CheckQuestions ();
	}

	public void AnsD_OnClick() {
		if (answer [i] == 4) {			
			score++;
		} else {
		}

		CheckQuestions ();
	}

	void CheckQuestions() {
		if (noOfQuestions < 50)
			LoadQuestion ();
		else {
			scoreText = scoreObject.GetComponent<Text> ();
			scoreText.text = score.ToString () + "/50";

			if (!SaveManager.Instance.state.isPreQuizDone) {
				SaveManager.Instance.SetPreQuizScore (score);
				SaveManager.Instance.Save (SaveManager.Instance.currentUser);
				gameObject.SetActive (false);
			} else {
				SaveManager.Instance.SetPostQuizScore (score);
				SaveManager.Instance.Save (SaveManager.Instance.currentUser);
				gameObject.SetActive (false);
			}
		}
	}

	int GetRandomNum() {
		var range = Enumerable.Range (0, 50).Where (o => !exclude.Contains (o));
		var rand = new System.Random ();
		int index = rand.Next (0, 49 - exclude.Count);
		return range.ElementAt (index);
	}

	public void NextScene() {
		if (!SaveManager.Instance.state.isPostQuizDone) {
			LoadingScreenControl.Instance.LoadScene ("Meeting");
		} else {
			LoadingScreenControl.Instance.LoadScene ("Credits");
		}
	}
}
