using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public bool canMove;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private bool playerMoving;
	private Vector2 lastMove;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerMoving = false;

		if (!canMove) 
		{
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (CrossPlatformInputManager.GetAxisRaw ("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2 (CrossPlatformInputManager.GetAxisRaw ("Horizontal") * moveSpeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (CrossPlatformInputManager.GetAxisRaw ("Horizontal"), 0);
		}

		if (CrossPlatformInputManager.GetAxisRaw ("Vertical") > 0.5f || CrossPlatformInputManager.GetAxisRaw ("Vertical") < -0.5f) 
		{
			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, CrossPlatformInputManager.GetAxisRaw ("Vertical") * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0, CrossPlatformInputManager.GetAxisRaw ("Vertical"));
		}

		if (CrossPlatformInputManager.GetAxisRaw ("Horizontal") < 0.5f && CrossPlatformInputManager.GetAxisRaw ("Horizontal") > -0.5f) 
		{
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}

		if (CrossPlatformInputManager.GetAxisRaw ("Vertical") < 0.5f && CrossPlatformInputManager.GetAxisRaw ("Vertical") > -0.5f) 
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
		}

		anim.SetFloat ("MoveX", CrossPlatformInputManager.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY", CrossPlatformInputManager.GetAxisRaw("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
