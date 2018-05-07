using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game4_LevelController : MonoBehaviour {
    float timer;
    public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer == 5f)
        {
            timerText.text = timer.ToString();
        }

	}
}
