using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;  // Ensure this is present at the top of your file
using UnityEngine;

public class EndlessGameManager : MonoBehaviour
{
    public static event Action NewWave;
    int _wave = 1;
    public List<GameObject> _disableSpawnpoint;  // Change to List to use RemoveAt()
    private bool _isWaitingForWave = false;  // To prevent multiple coroutine calls

    void SpawnEnemy()
    {
        NewWave?.Invoke();
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && !_isWaitingForWave)  // Check if coroutine is already running
        {
            StartCoroutine(Wave());
        } 
    }

    IEnumerator Wave()
    {
        _isWaitingForWave = true;  // Set flag to prevent multiple calls
        yield return new WaitForSeconds(6f);
        _wave++;
        SpawnEnemy();
        if(_wave % 5 == 0)
        {
            IncreaseDiff();
        }
        _isWaitingForWave = false;  // Reset flag after wave starts
    }

    void IncreaseDiff()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<CharacterMovement>().WalkSpeed += 0.5f;
        }

        // Handle spawn point activation and removal
        if(_disableSpawnpoint.Count > 0)
        {
            _disableSpawnpoint[0].SetActive(true);  // Enable the spawn point
            _disableSpawnpoint.RemoveAt(0);  // Remove it from the list
        }
    }
}
