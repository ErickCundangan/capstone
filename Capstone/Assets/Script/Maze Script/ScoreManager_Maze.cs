using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager_Maze : MonoBehaviour {
    public static ScoreManager_Maze Instance { set; get; }
    public float currentScore;
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
            if ( Mathf.Floor(time) <= oneStarScore) //one star
            {
                stars.sprite = starSprites[2];
                currentScore = 3f;
            }
            else if (Mathf.Floor(time) <= twoStarScore) //two sta
            {
                stars.sprite = starSprites[1];
                currentScore = 2f;
            }
            else if (Mathf.Floor(time) >= threeStarScore)//three star
            {
                stars.sprite = starSprites[0];
                currentScore = 1f;
            }
            flag = true;
        }
    }

    void TallyScore()
    {
        if (StageClear.Instance.isStageComplete)
        {
            if(time <= oneStarScore) //one star
            {
                stars.sprite = starSprites[2];
                currentScore = 3f;
            }
            else if (time <= twoStarScore) //two sta
            {
                stars.sprite = starSprites[1];
                currentScore = 2f;
            }
            else if(time <= threeStarScore)//three star
            {
                stars.sprite = starSprites[0];
                currentScore = 1f;
            }
            Debug.Log("star = " + currentScore);
        }
    }
}
