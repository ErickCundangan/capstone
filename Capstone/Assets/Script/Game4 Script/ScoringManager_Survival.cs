using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoringManager_Survival : MonoBehaviour {
    public static ScoringManager_Survival Instance { set; get; }
    public int currentScore;
    public float threeStarScore;
    public float twoStarScore;
    public float oneStarScore;

    public float time;
    public int kills;

    public Image stars;
    public Sprite[] starSprites;
    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        kills = Game4_PlayerController.Instance.kills;

        Debug.Log("Tally");
        if (Game4_PlayerController.Instance.isStageClear)
        {
			if (time <= threeStarScore) {
				stars.sprite = starSprites [0];
				currentScore = 3;
			} else if (time <= twoStarScore && time > threeStarScore) {
				stars.sprite = starSprites [1];
				currentScore = 2;
			} else if (time <= oneStarScore && time > twoStarScore) {
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
            
        }
    }
}
