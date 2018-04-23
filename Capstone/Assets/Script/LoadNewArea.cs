    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNewArea : MonoBehaviour {
    PlayerController thePlayer;

    public  string  levelToLoad;
    public  int     ExitCounter;

    public  float   timeLeft;
    private float   minutes;
    private float   seconds;
    public bool    stopTime = false;

    public  Text    counter;
    public  Text    timeCounter;



	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Talk to counter
        counter.text = ExitCounter.ToString();

        //Timer counter
        if (!stopTime)
        {
            if (timeLeft == 0 || timeLeft < 0)
            {
                stopTime = true;
                Debug.Log("Game Over");
                thePlayer.canMove = false;

                return;
            }

            timeLeft -= Time.deltaTime;
            minutes = Mathf.Floor(timeLeft / 60);
            seconds = timeLeft % 60;

            timeCounter.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    //Entry to next level
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Heneral Luna") {
            if (ExitCounter == 4)
            {
                SceneManager.LoadScene(levelToLoad);
            }
		}
	}
}
