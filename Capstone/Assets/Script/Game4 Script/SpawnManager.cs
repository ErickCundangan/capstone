using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {
    public GameObject enemy;
    private float minutes;
    private float seconds;
    public bool stopTime = false;

    public float spawnTime = 3f;
    public float time;
    public float lastTime;
    public float interval;
    public Transform[] spawnPoints;


    public Text textTime;
    // Use this for initialization
    void Start () {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating("Spawn", 0, spawnTime);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time > lastTime + spawnTime)                 //Spawn an enemy every interval
        {
            Debug.Log("MODOLO 5");
            spawnTime -= 0.2f;
            Spawn();
            lastTime = time;
        }
        
        minutes = Mathf.Floor(time / 60);
        seconds = time % 60;
        //Debug.Log("Time: " + time);
        textTime.text = string.Format("Time: {0:0}:{1:00}", minutes, seconds);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        
    }
}
