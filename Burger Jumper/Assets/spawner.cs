using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    float nextSpawnTime;

    public GameObject[] enemy;

    public Transform[] spawnpoints;

    public static int numberOfEnemies;
 
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemies <= 5){
            if (Time.time > nextSpawnTime){
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
            Instantiate(enemy[UnityEngine.Random.Range(0, enemy.Length)], randomSpawnPoint.position, Quaternion.identity);
            numberOfEnemies++;
            Debug.Log("ENEMIES ON SCENE: " + numberOfEnemies);
        }
        }
    }
}
