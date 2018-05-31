using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
	public GameObject game1;
	Button[] game1Stages;
	public GameObject game2;
	Button[] game2Stages;
	public GameObject game3;
	Button[] game3Stages;
	public GameObject game4;
	Button[] game4Stages;

	public Image g1s1;
	public Image g1s2;
	public Image g1s3;
	public Image g2s1;
	public Image g2s2;
	public Image g2s3;
	public Image g2s4;
	public Image g3s1;
	public Image g3s2;
	public Image g3s3;
	public Image g3s4;
	public Image g4s1;
	public Sprite[] stars;
	// Use this for initialization
	void Start () {
		game1Stages = game1.GetComponentsInChildren<Button> ();
		game2Stages = game2.GetComponentsInChildren<Button> ();
		game3Stages = game3.GetComponentsInChildren<Button> ();
		game4Stages = game4.GetComponentsInChildren<Button> ();

		foreach (Button stage in game1Stages) {
			stage.interactable = false;
		}
		foreach (Button stage in game2Stages) {
			stage.interactable = false;
		}

		foreach (Button stage in game3Stages) {
			stage.interactable = false;
		}

		foreach (Button stage in game4Stages) {
			stage.interactable = false;
		}

		game1Stages [0].interactable = true;
		if (SaveManager.Instance.isStageCleared (1, 0))
			game1Stages [1].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (1, 1))
			game1Stages [2].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (1, 2))
			game2Stages [0].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (2, 0))
			game2Stages [1].interactable = true;

		if (SaveManager.Instance.isStageCleared (2, 1))
			game2Stages [2].interactable = true;

		if (SaveManager.Instance.isStageCleared (2, 2))
			game2Stages [3].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (2, 3))
			game3Stages [0].interactable = true;

		if (SaveManager.Instance.isStageCleared (3, 0))
			game3Stages [1].interactable = true;

		if (SaveManager.Instance.isStageCleared (3, 1))
			game3Stages [2].interactable = true;
		
		if (SaveManager.Instance.isStageCleared (3, 2))
			game3Stages [3].interactable = true;

		if (SaveManager.Instance.isStageCleared (3, 3))
			game4Stages [0].interactable = true;

		if (SaveManager.Instance.isStageCleared (4, 0))
			game4Stages [1].interactable = true;

		g1s1.sprite = LoadStars(1,1);
		g1s2.sprite = LoadStars(1,2);
		g1s3.sprite = LoadStars(1,3);
		g2s1.sprite = LoadStars(2,1);
		g2s2.sprite = LoadStars(2,2);
		g2s3.sprite = LoadStars(2,3);
		g2s4.sprite = LoadStars(2,4);
		g3s1.sprite = LoadStars(3,1);
		g3s2.sprite = LoadStars(3,2);
		g3s3.sprite = LoadStars(3,3);
		g3s4.sprite = LoadStars(3,4);
		g4s1.sprite = LoadStars(4,1);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void PlayOnClick() {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}

	Sprite LoadStars(int game, int stage) {
		int score;
		if (SaveManager.Instance.GetScore (game, stage) == 3)
			return stars [0];
		else if (SaveManager.Instance.GetScore (game, stage) == 2)
			return stars [1];
		else if (SaveManager.Instance.GetScore (game, stage) == 1)
			return stars [2];
		else
			return stars [3];
	}
}
