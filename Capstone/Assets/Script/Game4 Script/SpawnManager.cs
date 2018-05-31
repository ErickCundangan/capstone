using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager Instance { set; get; }
    public GameObject enemy;
    public GameObject enemyGun;
    private float minutes;
    private float seconds;
    public bool stopTime = false;

    public float spawnTimeSword = 5f;
    public float spawnTimeGun = 10f;
    public float time;
    public float lastTimeSword;
    public float lastTimeGun;
    //public float interval;
    public float killsAmp;
    public Transform[] spawnPoints;


    public Text textTime;
    public Text textKills;
    //public float speedSword = 1.1f;
    //public float speedGun = 0.5f;
    // Use this for initialization
    void Start () {
        Instance = this;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating("Spawn", 0, spawnTime);
        //Instantiate(enemy, spawnPoints[0].position, spawnPoints[0].rotation);
        //Instantiate(enemy, spawnPoints[1].position, spawnPoints[1].rotation);
        //Instantiate(enemy, spawnPoints[2].position, spawnPoints[2].rotation);
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        killsAmp = Game4_PlayerController.Instance.kills / 30;

        if (!(Game4_PlayerController.Instance.playerHealth <= 0) && !(Game4_PlayerController.Instance.isStageClear))
        {
            if (time - killsAmp > lastTimeSword + spawnTimeSword)             //Spawn an enemy every interval
            {
                if (!(spawnTimeSword <= 1))
                    spawnTimeSword -= 0.25f;

                //if(!(speedSword >= 2f))
                //    speedSword += 0.05f;

                SpawnSword();
                lastTimeSword = time;
            }

            if (time - killsAmp > lastTimeGun + spawnTimeGun)                 //Spawn an enemy every interval
            {
                if (!(spawnTimeGun <= 1))
                    spawnTimeGun -= 0.5f;

                //if (!(speedGun >= 1.5f))
                //   speedGun += 0.05f;

                SpawnGun();
                lastTimeGun = time;
            }

            minutes = Mathf.Floor(time / 60);
            seconds = time % 60;
            //Debug.Log("Time: " + time);
            textTime.text = string.Format("Time: {0:0}:{1:00}", minutes, seconds);
            textKills.text = "Kills: " + Game4_PlayerController.Instance.kills.ToString();
        }
       
    }

    void SpawnSword()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        
        
    }
    void SpawnGun()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemyGun, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
