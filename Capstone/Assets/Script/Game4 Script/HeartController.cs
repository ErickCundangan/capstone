using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {
    private Transform heart;
    private float speed = 0.005f;
    private float startY;
    // Use this for initialization
    void Start () {
        heart = GetComponent<Transform>();
        startY = heart.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        heart.position += Vector3.up * speed;

        if (heart.position.y <= (startY - 0.05f) || heart.position.y >= (startY + 0.05f))
        {
            speed = -speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Add health");
            Game4_PlayerController.Instance.playerHealth += 10f;
            if (Game4_PlayerController.Instance.playerHealth >= 100f)
                Game4_PlayerController.Instance.playerHealth = 100f;
            HeartSpawnController.Instance.isExisting = false;
            Destroy(this.gameObject);
        }
    }
    
}
