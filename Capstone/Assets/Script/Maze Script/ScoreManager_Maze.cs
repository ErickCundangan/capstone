using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager_Maze : MonoBehaviour {
    public static ScoreManager_Maze Instance { set; get; }
    public float currentScore;
    public int threeStarScore;
    public int twoStarScore;
    public int oneStarScore;

    public float time;
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
    }

    void TallyScore()
    {
        if (StageClear.Instance.isStageComplete)
        {
            if(time <= oneStarScore) //one star
            {
                currentScore = 1f;
            }
            else if (time <= twoStarScore) //two sta
            {
                currentScore = 2f;
            }
            else if(time <= threeStarScore)//three star
            {
                currentScore = 3f;
            }
            Debug.Log("star = " + currentScore);
        }
    }
}
