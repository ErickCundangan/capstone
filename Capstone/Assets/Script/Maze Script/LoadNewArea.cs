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
<<<<<<< HEAD:Capstone/Assets/Script/LoadNewArea.cs
	public  int 	ExitRequirement;
=======
    public  int     ExitRequirement;
>>>>>>> master:Capstone/Assets/Script/Maze Script/LoadNewArea.cs

    public  float   timeLeft;
    private float   minutes;
    private float   seconds;
<<<<<<< HEAD:Capstone/Assets/Script/LoadNewArea.cs
	public bool    stopTime = false;
=======
    public  bool    stopTime = false;
>>>>>>> master:Capstone/Assets/Script/Maze Script/LoadNewArea.cs

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
            if (timeLeft == 0 || timeLeft < 0)
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

            timeCounter.text = string.Format("{0:0}:{1:00}", minutes, seconds);
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
<<<<<<< HEAD:Capstone/Assets/Script/LoadNewArea.cs
			if (ExitCounter == ExitRequirement)
=======
            if (ExitCounter == ExitRequirement)
>>>>>>> master:Capstone/Assets/Script/Maze Script/LoadNewArea.cs
            {
				string sceneName = SceneManager.GetActiveScene().name;
				char[] gameStage = sceneName.Where (char.IsDigit).ToArray ();

				SaveManager.Instance.completeStage (gameStage[0] - '0', gameStage[1] - '0' - 1);
				SaveManager.Instance.Save ();
				buttons.SetActive (true);
				stageClearPanel.SetActive (true);
            }
		}
	}
}
