using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController_Game4 : MonoBehaviour
{
    Animator anim;
    public Transform target;
    public float speed;
    private Vector2 direction;
    public float distance;
    Rigidbody2D rigid;

    public bool isNotDead;
    public bool isMoving;
    //attacking
    public bool isAttacking;
    public float attackRange;
    public float attackTime;
    public float attackCooldown = 5f;
    private Vector2 moveInput;


    //shooting
    public GameObject shotUp;
    public GameObject shotRight;
    public GameObject shotDown;
    public GameObject shotLeft;
    public Transform shotSpawn;

    // Use this for initialization
    void Start()
    {
        target = FindObjectOfType<Game4_PlayerController>().transform;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        isNotDead = true;
        isMoving = true;
        isAttacking = false;

    }

    // Update is called once per frame
    void Update()
    {

        ChangeDirection();

        isMoving = true;
        //distance = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        distance = Vector2.Distance(transform.position, target.position);
        direction = (target.transform.position - transform.position).normalized;


        if (isNotDead)
        {
            if (distance > attackRange)            //MOVCE
            {
                if (isMoving)
                {
                    FollowTarget();
                }
            }
            else                                      //ATTACK
            {
                isMoving = false;
                isAttacking = true;
                Attack();
            }
        }
        else
        {
            Death();                                    //DIE
        }
        //if (isNotDead)
        //{
        //    if (isAttacking)
        //    {
        //        Attack();
        //    }
        //    else
        //    {
        //        FollowTarget();
        //    }
        //}
        //else
        //{
        //    Death();
        //}

        attackTime += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            isNotDead = false;
            Death();
        }
    }

    private void FollowTarget()
    {
        isNotDead = true;
        isMoving = true;

        if (target != null)
        {
            float distanceTarget = Vector2.Distance(transform.position, target.position);

            if (distanceTarget <= 1f) //1f
            {
                rigid.isKinematic = true;
                return;
            }
            else
            {
                rigid.isKinematic = false;
            }
            //moveInput = new Vector2(direction.x, direction.y).normalized;

            //rigid.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);

            isAttacking = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void ChangeDirection()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Movement"), 1);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("Dead"), 0);

        anim.SetBool("isMoving", true);

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
    }

    private void Death()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Movement"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("Dead"), 1);
        Debug.Log("HIT!!");
        anim.SetBool("isDead", true);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void DestroyCollider()
    {
        Destroy(gameObject.GetComponents<Collider2D>()[0]);
    }

    public void Attack()
    {
        if (isAttacking)
        {
            if (attackTime >= attackCooldown)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

                isAttacking = true;

                anim.SetBool("isAttack", true);
                anim.SetLayerWeight(anim.GetLayerIndex("Movement"), 0);
                anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 1);
                anim.SetLayerWeight(anim.GetLayerIndex("Dead"), 0);

                anim.SetBool("isMoving", false);

                attackTime = 0;
                rigid.constraints = RigidbodyConstraints2D.FreezeAll;

                //diagonal checking direction
                if ((direction.x > -0.71f && direction.x < 0.71f)
                    && (direction.y > 0 && direction.y > 0))
                {
                    Instantiate(shotUp, shotSpawn.position, shotSpawn.rotation);
                }
                else if ((direction.y < 0.71f && direction.y > -0.71f) &&
                    (direction.x < 0 && direction.x < 0))

                {
                    Instantiate(shotLeft, shotSpawn.position, shotSpawn.rotation);
                }
                else if ((direction.x > -0.71f && direction.x < 0.71f)
                    && (direction.y < 0 && direction.y < 0))

                {
                    Instantiate(shotDown, shotSpawn.position, shotSpawn.rotation);
                }
                else if ((direction.x > 0 && direction.x > 0)
                    && (direction.y < 0.71f && direction.y > -0.71f))
                {
                    Instantiate(shotRight, shotSpawn.position, shotSpawn.rotation);
                }
            }
            else
            {
                anim.SetBool("isAttack", false);
            }
        }
        else
        {
            isMoving = true;
        }
       
    }
}