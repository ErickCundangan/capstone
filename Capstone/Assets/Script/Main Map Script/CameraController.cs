using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
	public float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		if (followTarget.transform.position.x <= minX)
			targetPos.x = minX;

		if (followTarget.transform.position.x >= maxX)
			targetPos.x = maxX;

		if (followTarget.transform.position.y <= minY)
			targetPos.y = minY;

		if (followTarget.transform.position.y >= maxY)
			targetPos.y = maxY;

		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}