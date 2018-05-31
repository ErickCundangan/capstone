using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager_Survival : MonoBehaviour {
    public static ScoringManager_Survival Instance { set; get; }
    public float currentScore;
    public float threeStarScore;
    public float twoStarScore;
    public float oneStarScore;
    public float achievedStar;

    public float time;
    public int kills;
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
                currentScore = 3f;
            }else if (kills >= 200 && time <= twoStarScore)
            {
                currentScore = 2f;
            }
            else if (kills >= 200 && time >= threeStarScore)
            {
                currentScore = 1f;
            }

            achievedStar = currentScore;

            Debug.Log("Satr = " + achievedStar);
            CancelInvoke();
        }
    }
}
