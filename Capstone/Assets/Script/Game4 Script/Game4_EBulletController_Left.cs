﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_EBulletController_Left : MonoBehaviour { 
    public static Game4_EBulletController_Left Instance { set; get; }
    public float attackDamage;

    private Transform bullet;
    public float speed;
    //public float lastTime;

    // Use this for initialization
    void Start()
    {
        //if (SpawnManager.Instance.time > lastTime)
        //{
        //    attackDamage += 0.4f;
        //    lastTime = SpawnManager.Instance.time;
        //}
        bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        bullet.position += Vector3.left * speed;
        if (bullet.position.x <= 1.3f)
        {
             Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Game4_PlayerController.Instance.playerHealth -= attackDamage;
            Destroy(gameObject);
        }
        //Debug.Log("player health = " + Game4_PlayerController.Instance.playerHealth + "-\n attack =  " + attackDamage);
    }
}
