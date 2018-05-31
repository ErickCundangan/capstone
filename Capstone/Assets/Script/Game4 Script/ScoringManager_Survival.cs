using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManager_Survival : MonoBehaviour {
    public static ScoringManager_Survival Instance { set; get; }
    public float currentScore;
    public float threeStarScore;
    public float twoStarScore;
    public float oneStarScore;
    public float achievedStar;

    public float time;
    public int kills;

    public Image stars;
    public Sprite[] starSprites;
    // Use this for initialization
    void Start()
    {
        Instance = this;
        InvokeRepeating("TallyScore", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        kills = Game4_PlayerController.Instance.kills;
    }

    void TallyScore()
    {
        Debug.Log("Tally");
        if (Game4_PlayerController.Instance.isStageClear)
        {
            if (kills >= 200 && time <= threeStarScore)
            {
                stars.sprite = starSprites[2];
                currentScore = 3f;
            }
            else if (kills >= 200 && time <= twoStarScore)
            {
                stars.sprite = starSprites[1];
                currentScore = 2f;
            }
            else if (kills >= 200 && time >= threeStarScore)
            {
                stars.sprite = starSprites[0];
                currentScore = 1f;
            }

            achievedStar = currentScore;

            Debug.Log("Satr = " + achievedStar);
            CancelInvoke();
        }
    }
}
