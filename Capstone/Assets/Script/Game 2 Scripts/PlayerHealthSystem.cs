using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour {

	public Sprite[] heartSprites;
	private Image heartUI;

	// Use this for initialization
	void Start () {
		heartUI = GetComponent<Image> ();
		heartUI.sprite = heartSprites [PlayerController2.playerHealth];
	}
	
	// Update is called once per frame
	void Update () {
		heartUI.sprite = heartSprites [PlayerController2.playerHealth];
	}
}
