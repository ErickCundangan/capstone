using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager_Maze : MonoBehaviour {
    public static ScoreManager_Maze Instance { set; get; }
    public int currentScore;
    public int threeStarScore;
    public int twoStarScore;
    public int oneStarScore;

    public float time;

    public Image stars;
    public Sprite[] starSprites;

    bool flag;
    // Use this for initialization
    void Start()
    {
        Instance = this;
        //InvokeRepeating("TallyScore", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        time = LoadNewArea.Instance.timeLeft;

        if (LoadNewArea.Instance.stageComplete && !flag) {
			if (Mathf.Floor(time) >= threeStarScore) {
				stars.sprite = starSprites [0];
				currentScore = 3;
			} else if (Mathf.Floor(time) >= twoStarScore && Mathf.Floor(time) < threeStarScore) {
				stars.sprite = starSprites [1];
				currentScore = 2;
			} else if (Mathf.Floor(time) > oneStarScore && Mathf.Floor(time) < twoStarScore) {
				stars.sprite = starSprites [2];
				currentScore = 1;
			}

            string sceneName = SceneManager.GetActiveScene().name;
            char[] gameStage = sceneName.Where(char.IsDigit).ToArray();

            if (SaveManager.Instance.GetScore(gameStage[0] - '0', gameStage[1] - '0') < currentScore)
            {
                SaveManager.Instance.SetHighScore(gameStage[0] - '0', gameStage[1] - '0', currentScore);
                SaveManager.Instance.Save(SaveManager.Instance.currentUser);
            }

            flag = true;
        }
    }
}
