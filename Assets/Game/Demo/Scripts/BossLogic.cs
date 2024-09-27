using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public static event Action EnemySpawner;
    public float spawnDelay = 5f;   // Delay before spawning a new enemy wave

    private bool isWaitingForSpawn = false; // To prevent multiple spawn calls

    void Update()
    {
        // Find all GameObjects in the scene with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;

        // Check if there are no enemies and we're not already waiting for the spawn
        if (enemyCount == 0 && !isWaitingForSpawn)
        {
            // Start the coroutine to delay and spawn new enemies
            StartCoroutine(WaitAndSpawn());
        }
    }

    IEnumerator WaitAndSpawn()
    {
        isWaitingForSpawn = true; // Prevent the coroutine from being called again
        Debug.Log("No enemies left. Waiting for " + spawnDelay + " seconds...");

        // Wait for the specified delay time
        yield return new WaitForSeconds(spawnDelay);

        // Trigger the enemy spawn event
        if (EnemySpawner != null)
        {
            EnemySpawner?.Invoke();
            Debug.Log("New enemies spawned!");
        }

        // Reset the waiting flag
        isWaitingForSpawn = false;
    }
}
