using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_BulletController_Right : MonoBehaviour
{
    private Transform bullet;
    private Animator anim;
    public float speed;

    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.right * speed;

        if (bullet.position.x >= 45.75)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.tag == "Player"))
            Destroy(gameObject);
        if (other.tag == "Enemy")
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
