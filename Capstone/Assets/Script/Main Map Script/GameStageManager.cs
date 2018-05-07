using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStageManager : MonoBehaviour {
	public GameObject game;
	public GameObject player;
	bool playerInsideTrigger = false;
	PlayerController thePlayer;

	// Use this for initialization
	void Start ()
	{
		game.SetActive (false);
		thePlayer = FindObjectOfType<PlayerController>();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.name == "Heneral Luna") 
		{
			playerInsideTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Heneral Luna") 
		{
			playerInsideTrigger = false;
		}
	}

	public void OnClick ()
	{
		if (playerInsideTrigger) {
			game.SetActive (true);
			thePlayer.canMove = false;
		}
	}

	public void Close()
	{
		game.SetActive (false);
		thePlayer.canMove = true;
	}
}
