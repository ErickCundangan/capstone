using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_EBulletController_Down : MonoBehaviour {
    public static Game4_EBulletController_Down Instance { set; get; }
    public float attackDamage;

    private Transform bullet;
    public float speed;
    //public float lastTime;

    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (SpawnManager.Instance.time > lastTime)
        //{
        //    attackDamage += 0.4f;
        //    lastTime = SpawnManager.Instance.time;
        //}
        bullet.position += Vector3.down * speed;
        if (bullet.position.y <= -18.5)
        {
             Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Game4_PlayerController.Instance.playerHealth -= Mathf.Floor(attackDamage);
            Destroy(gameObject);
            
        }
    }
}
