using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_EBulletController_Right : MonoBehaviour {
    public static Game4_EBulletController_Right Instance { set; get; }
    public float attackDamage;

    private Transform bullet;
    public float speed;
    public float lastTime;

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

        bullet.position += Vector3.right * speed;
        if (bullet.position.x >= 45.75)
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
