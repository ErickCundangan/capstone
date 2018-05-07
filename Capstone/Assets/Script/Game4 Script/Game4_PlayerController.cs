using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Game4_PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public bool canMove;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    public bool playerMoving;
    private Vector2 lastMove;
    public bool isAttack;

    //shooting
    public static Game4_PlayerController Instance { set; get; }
    public GameObject shotUp;
    public GameObject shotRight;
    public GameObject shotDown;
    public GameObject shotLeft;
    public Transform shotSpawn;
    public string direction = "up";

    public float playerHealth;

    public int kills;

    private bool isStageClear;
    // Use this for initialization
    void Start()
    {
        playerHealth = 100f;
        Screen.orientation = ScreenOrientation.Landscape;
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //shooting
        lastMove = new Vector2(0, -1f);

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ChecIfStageIsClear();

        playerMoving = false;

        if (playerHealth >= 0)
        {
            if (!canMove)
            {
                myRigidbody.velocity = Vector2.zero;
                return;
            }

            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0);

            }

            if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0.5f || CrossPlatformInputManager.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, CrossPlatformInputManager.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0, CrossPlatformInputManager.GetAxisRaw("Vertical"));

            }

            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0.5f && CrossPlatformInputManager.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);

            }

            if (CrossPlatformInputManager.GetAxisRaw("Vertical") < 0.5f && CrossPlatformInputManager.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            //diagonal checking direction
            if ((CrossPlatformInputManager.GetAxisRaw("Horizontal") > -0.71f && CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0.71f)
                && (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0 && CrossPlatformInputManager.GetAxisRaw("Vertical") > 0))

            {
                direction = "up";
            }
            else if ((CrossPlatformInputManager.GetAxisRaw("Vertical") < 0.71f && CrossPlatformInputManager.GetAxisRaw("Vertical") > -0.71f) &&
                (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0 && CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0))

            {
                direction = "left";
            }
            else if ((CrossPlatformInputManager.GetAxisRaw("Horizontal") > -0.71f && CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0.71f)
                && (CrossPlatformInputManager.GetAxisRaw("Vertical") < 0 && CrossPlatformInputManager.GetAxisRaw("Vertical") < 0))

            {
                direction = "down";
            }
            else if ((CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0 && CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0)
                && (CrossPlatformInputManager.GetAxisRaw("Vertical") < 0.71f && CrossPlatformInputManager.GetAxisRaw("Vertical") > -0.71f))

            {
                direction = "right";
            }

            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);

            HandleAnimation();
        }
        else
        {
            Debug.Log("Game Over: Player dead");
            Destroy(gameObject);
        }
    }

    public void HandleAnimation()
    {
        if (playerMoving)
        {
            anim.SetLayerWeight(0, 1);

            anim.SetFloat("MoveX", CrossPlatformInputManager.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", CrossPlatformInputManager.GetAxisRaw("Vertical"));

        }
        if (isAttack)
        {
            anim.SetLayerWeight(1, 1);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("FIRE");
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
            if (direction == "up")
            {
                Instantiate(shotUp, shotSpawn.position, shotSpawn.rotation);
            }
            if (direction == "right")
            {
                Instantiate(shotRight, shotSpawn.position, shotSpawn.rotation);
            }
            if (direction == "down")
            {
                Instantiate(shotDown, shotSpawn.position, shotSpawn.rotation);
            }
            if (direction == "left")
            {
                Instantiate(shotLeft, shotSpawn.position, shotSpawn.rotation);
            }
            
            isAttack = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        //isAttack = true;

        anim.SetBool("isAttack", isAttack);

        //yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(0.2f);

        StopAttack();
        
    }
    
    public void StopAttack()
    {
        isAttack = false;

        anim.SetBool("isAttack", isAttack);
    }

    public void OnClick()
    {
        if(direction == "up")
        {
            Instantiate(shotUp, shotSpawn.position, shotSpawn.rotation);
        }
        if(direction == "right")
        {
            Instantiate(shotRight, shotSpawn.position, shotSpawn.rotation);
        }
        if(direction == "down")
        {
            Instantiate(shotDown, shotSpawn.position, shotSpawn.rotation);
        }
        if(direction == "left")
        {
            Instantiate(shotLeft, shotSpawn.position, shotSpawn.rotation);
        }


        isAttack = true;
        StartCoroutine(Attack());
    }

    void ChecIfStageIsClear()
    {
        if(kills >= 10)
        {
            isStageClear = true;
			SaveManager.Instance.completeStage (4, 0);
			SaveManager.Instance.Save (SaveManager.Instance.currentUser);
        }
    }
}
