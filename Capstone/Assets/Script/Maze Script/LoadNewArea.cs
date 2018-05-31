using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class LoadNewArea : MonoBehaviour {
    PlayerController thePlayer;
	public GameObject stageClearPanel;
	public GameObject gameOverPanel;
	public GameObject buttons;
    public  string  levelToLoad;
    public  int     ExitCounter;

	public  int 	ExitRequirement;

    public  float   timeLeft;
    private float   minutes;
    private float   seconds;

	public bool    stopTime = false;

    public  Text    counter;
    public  Text    timeCounter;

    Animator anim;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Talk to counter
        counter.text = ExitCounter.ToString();

        //Timer counter
        if (!stopTime)
        {
            if (timeLeft <= 0)
            {
                stopTime = true;
                thePlayer.canMove = false;
				gameOverPanel.SetActive (true);
				buttons.SetActive (true);
                return;
            }

            timeLeft -= Time.deltaTime;
            minutes = Mathf.Floor(timeLeft / 60);
            seconds = timeLeft % 60;

            if(!(timeLeft <= 0))
                timeCounter.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            else
                timeCounter.text = string.Format("{0:0}:{1:00}", 0, 0);
        }

        //Exit Arrow animation
        if(ExitCounter == ExitRequirement)
        {
            anim.SetBool("isLevelComplete", true);
        }
        else
        {
            anim.SetBool("isLevelComplete", false);
        }
    }

    //Entry to next level
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Heneral Luna") {
            if (ExitCounter == ExitRequirement)
            {
				string sceneName = SceneManager.GetActiveScene().name;
				char[] gameStage = sceneName.Where (char.IsDigit).ToArray ();

				//SaveManager.Instance.completeStage (gameStage[0] - '0', gameStage[1] - '0' - 1);
				//SaveManager.Instance.Save (SaveManager.Instance.currentUser);
				buttons.SetActive (true);
				stageClearPanel.SetActive (true);
				Time.timeScale = 0;
            }
		}
	}
}
