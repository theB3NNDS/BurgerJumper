using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies; // Reference to the prefab to spawn
    public float spawnMinInterval = 5.0f; // Time interval between spawns (in seconds)
    public float spawnMaxInterval = 15.0f;
    public float spawnOffset = 1.0f; // Distance to spawn the enemy in front of the spawner

    void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true) // Loop indefinitely to keep spawning
        {
            // Get the spawner's position with an offset in the Z direction (forward)
            Vector3 spawnPosition = transform.position + Vector3.forward * spawnOffset;

            // Spawn the prefab with random enemy selection
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], spawnPosition, transform.rotation);

            // Wait for the spawn interval before spawning again
            yield return new WaitForSeconds(UnityEngine.Random.Range(spawnMinInterval, spawnMaxInterval));
        }
    }
}