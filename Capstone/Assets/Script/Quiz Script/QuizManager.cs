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

	bool flag = false;

	public void AnsA_OnClick() {
		if (flag)
			return;
		
		flag = true;
		if (answer [i] == 1) {
			score++;
			ansA.color = new Color (0.5f, 1f, 0.5f, 1f);
		} else {
			ansA.color = new Color (1f, 0.2f, 0.2f, 1f);
		}

		StartCoroutine (Wait ());
	}

	public void AnsB_OnClick() {
		if (flag)
			return;
		
		flag = true;
		if (answer [i] == 2) {
			score++;
			ansB.color = new Color (0.5f, 1f, 0.5f, 1f);
		} else {
			ansB.color = new Color (1f, 0.2f, 0.2f, 1f);
		}

		StartCoroutine (Wait ());
	}

	public void AnsC_OnClick() {
		if (ansC.text.Equals (""))
			return;

		if (flag)
			return;
		
		flag = true;
		if (answer [i] == 3) {
			score++;
			ansC.color = new Color (0.5f, 1f, 0.5f, 1f);
		} else {
			ansC.color = new Color (1f, 0.2f, 0.2f, 1f);
		}

		StartCoroutine (Wait ());
	}

	public void AnsD_OnClick() {
		if (ansD.text.Equals (""))
			return;
		
		if (flag)
			return;
		
		flag = true;
		if (answer [i] == 4) {			
			score++;
			ansD.color = new Color (0.5f, 1f, 0.5f, 1f);
		} else {
			ansD.color = new Color (1f, 0.2f, 0.2f, 1f);
		}

		StartCoroutine (Wait ());
	}

	IEnumerator Wait () {
		yield return new WaitForSeconds (1f);
		CheckQuestions ();
	}

	void CheckQuestions() {
		flag = false;
		ansA.color = new Color (0f, 0f, 0f, 1f);
		ansB.color = new Color (0f, 0f, 0f, 1f);
		ansC.color = new Color (0f, 0f, 0f, 1f);
		ansD.color = new Color (0f, 0f, 0f, 1f);
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

	void LoadQuestion() {
		noOfQuestions++;
		i = GetRandomNum ();
		exclude.Add (i);
		questionNo.text = "Question # " + noOfQuestions.ToString() + "/50";
		question.text = questions [i];
		ansA.text = answerA [i];
		ansB.text = answerB [i];
		ansC.text = answerC [i];
		ansD.text = answerD [i];
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
