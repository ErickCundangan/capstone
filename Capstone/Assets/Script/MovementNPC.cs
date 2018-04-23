using System.Collections.Generic;
using UnityEngine;

public class MovementNPC : MonoBehaviour
{

    public float movementSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidBody;

    [SerializeField]
    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    public Collider2D walkZone;

    private bool hasWalkZone;

    private Animator anim;

    private Vector2 tempMove;
    private Vector2 lastMove;
    
    public bool playerMoving;
    private bool isTalk;

    private bool playerInsideTrigger = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        myRigidBody = GetComponent<Rigidbody2D>();

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
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                case 0: //UP
                    playerMoving = true;
                    myRigidBody.velocity = new Vector2(0, movementSpeed);
                    tempMove = new Vector2(0, 1);
                    if (hasWalkZone && myRigidBody.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;

                    }
                    break;
                case 1://RIGHT
                    playerMoving = true;
                    myRigidBody.velocity = new Vector2(movementSpeed, 0);
                    tempMove = new Vector2(1, 0);
                    if (hasWalkZone && myRigidBody.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2://DOWN
                    playerMoving = true;
                    myRigidBody.velocity = new Vector2(0, -movementSpeed);
                    tempMove = new Vector2(0, -1);
                    if (hasWalkZone && myRigidBody.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3://LEFT
                    playerMoving = true;
                    myRigidBody.velocity = new Vector2(-movementSpeed, 0);
                    tempMove = new Vector2(-1, 0);
                    if (hasWalkZone && myRigidBody.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                playerMoving = false;
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

        if (!isTalk)
        {
            lastMove = tempMove;
            anim.SetFloat("MoveX", tempMove.x);
            anim.SetFloat("MoveY", tempMove.y);
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
        else
        {
            tempMove = new Vector2(0, 0);
            lastMove = tempMove;
            isWalking = false;
            anim.SetFloat("MoveX", tempMove.x);
            anim.SetFloat("MoveY", tempMove.y);
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    }

    private void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    public void OnClick()
    {
        Debug.Log("onclick");
        if (playerInsideTrigger)
        {
            isTalk = true;
            playerMoving = false;
        }
        else
        {
            isTalk = false;
            playerMoving = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Heneral Luna")
        {
            playerInsideTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Heneral Luna")
        {
            playerInsideTrigger = false;
        }
    }



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
