using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawnController : MonoBehaviour {
    public static HeartSpawnController Instance { set; get; }
    public float time;
    public float lastTime;
    private float spawnTime = 30f;

    public bool isExisting;

    public GameObject heart;

    public Transform[] spawnPoints;
    // Use this for initialization
    void Start () {
        Instance = this;
        isExisting = false;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if ((time >= lastTime + spawnTime) & !isExisting)
        {
            RandomSpawn();
            lastTime = time;
        }
	}

    void RandomSpawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(heart, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        isExisting = true;
    }
}
