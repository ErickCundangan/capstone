﻿using System.Collections.Generic;
using UnityEngine;

public class MovementNPC : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidBody;
    
    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    public int WalkDirection;

    public Collider2D walkZone;

    private bool hasWalkZone;

    private Animator anim;

    private Vector2 tempMove;
    private Vector2 lastMove;
    
    public bool npcsMoving;
    private bool isTalk;

    private DialogueManager dialogManager;
    GameObject NPC;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        myRigidBody = GetComponent<Rigidbody2D>();
        dialogManager = FindObjectOfType<DialogueManager>();
        NPC = FindObjectOfType<GameObject>();

        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)                              //is the NPC animating?
        {
            if (dialogManager.thePlayer.canMove)    //check if player is talking to NPC    
            {
                walkCounter -= Time.deltaTime;

                switch (WalkDirection)
                {
                    case 0: //UP
                        npcsMoving = true;
                        myRigidBody.velocity = new Vector2(0f, movementSpeed);
                        tempMove = new Vector2(0f, 1f);
                        
                        if (hasWalkZone && myRigidBody.position.y > maxWalkPoint.y)
                        {
                            isWalking = false;
                            npcsMoving = false;
                            waitCounter = waitTime;

                        }
                        break;
                    case 1://RIGHT
                        npcsMoving = true;
                        myRigidBody.velocity = new Vector2(movementSpeed, 0f);
                        tempMove = new Vector2(1f, 0f);
                        if (hasWalkZone && myRigidBody.position.x > maxWalkPoint.x)
                        {
                            isWalking = false;
                            npcsMoving = false;
                            waitCounter = waitTime;
                        }
                        break;
                    case 2://DOWN
                        npcsMoving = true;
                        myRigidBody.velocity = new Vector2(0f, -movementSpeed);
                        tempMove = new Vector2(0f, -1f);
                        if (hasWalkZone && myRigidBody.position.y < minWalkPoint.y)
                        {
                            isWalking = false;
                            npcsMoving = false;
                            waitCounter = waitTime;
                        }
                        break;
                    case 3://LEFT
                        npcsMoving = true;
                        myRigidBody.velocity = new Vector2(-movementSpeed, 0f);
                        tempMove = new Vector2(-1f, 0f);
                        if (hasWalkZone && myRigidBody.position.x < minWalkPoint.x)
                        {
                            isWalking = false;
                            npcsMoving = false;
                            waitCounter = waitTime;
                        }
                        break;
                }
                if (walkCounter < 0)
                {
                    npcsMoving = false;
                    isWalking = false;
                    waitCounter = waitTime;
                }
            }
            else
            {
                npcsMoving = false;
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

        lastMove = tempMove;
        anim.SetFloat("MoveX", tempMove.x);
        anim.SetFloat("MoveY", tempMove.y);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        anim.SetBool("PlayerMoving", npcsMoving);
    }

    private void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    //public void OnClick()
    //{
        
    //    Debug.Log("onclick");
    //    if (dialogManager.thePlayer.canMove)
    //    {
    //        isWalking = false;
    //        npcsMoving = false;
    //    }
    //    else
    //    {
    //        isWalking = false;
    //        npcsMoving = false;
    //    }
    //}

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.name == "Heneral Luna")
    //    {
    //        playerInsideTrigger = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.name == "Heneral Luna")
    //    {
    //        playerInsideTrigger = false;
    //    }
    //}



    //float speed = 5f;
    //public Transform target;

    //void Update()
    //{
    //    RotateNpc();
    //}

    //public void RotateNpc()
    //{
    //    Debug.Log("Enter rotation");
    //    Vector2 direction = target.position - target.position;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    //}
}
