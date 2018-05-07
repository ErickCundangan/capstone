using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

    public float attackDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Game4_PlayerController.Instance.playerHealth -= attackDamage;
        }
        //Debug.Log("player health = " + Game4_PlayerController.Instance.playerHealth + "-\n attack =  " + attackDamage);
    }
}
