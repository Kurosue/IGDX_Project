using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyToSpawn;

    void OnEnable() {
        DangerArea.OnAreaEntered += SpawnEnemyMethod;
    }

    void OnDisable() {
        DangerArea.OnAreaEntered -= SpawnEnemyMethod;
    }

    void SpawnEnemyMethod() {
        Instantiate(enemyToSpawn, transform.position, transform.rotation);;
    }
}
