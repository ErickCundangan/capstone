using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Transform target;
    Transform enemyTransform;
    public float speed = 3f;
    public float rotationSpeed = 10f;
    Vector3 upAxis = new Vector3(0f, 0f, -1f);

    void Start()
    {

    }

    void FixedUpdate()
    {

        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

}