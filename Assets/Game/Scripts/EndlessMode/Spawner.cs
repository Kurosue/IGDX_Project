using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _char;
    void OnEnable()
    {
        EndlessGameManager.NewWave += SpawnEnemy;
    }
    void OnDisable()
    {
        EndlessGameManager.NewWave -= SpawnEnemy;
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, _char.Length);

        // Instantiate the selected GameObject at the spawner's position and rotation
        Instantiate(_char[randomIndex], transform.position, transform.rotation);
    }
}
