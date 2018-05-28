using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;

    
    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;
        if (bullet.position.y >= -5.52)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.tag == "Player" || other.tag == "SpawnPoint"))
            Destroy(gameObject);
        if (other.tag == "Enemy" || other.tag == "EnemySword")
        {
            Game4_PlayerController.Instance.kills += 1;
        }

        if (other.tag == "Boss" && other.gameObject.GetComponent<Transform>().position.y <= 4)
        {
            BossController.Instance.bossHealth -= 1;
        }

        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);  
        }
    }
}
