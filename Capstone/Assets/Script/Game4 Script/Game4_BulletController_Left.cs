using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_BulletController_Left : MonoBehaviour
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
        bullet.position += Vector3.left * speed;

        if (bullet.position.x <= -10)
        {
            //Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            anim = other.gameObject.GetComponent<Animator>();
            if (anim != null)
                anim.SetBool("isDead", true);
            Destroy(gameObject);
        }

        if (other.tag == "Boss" && other.gameObject.GetComponent<Transform>().position.y <= 4)
        {
            BossController.Instance.bossHealth -= 1;
            Destroy(gameObject);
        }

        if (other.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
