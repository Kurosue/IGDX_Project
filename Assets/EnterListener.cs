using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterListener : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        if (audioSource == null) 
        {
            audioSource = GetComponent<AudioSource>();
        }

        DangerArea.OnAreaEntered += EnemySpawnSound;
    }

    void EnemySpawnSound()
    {
        audioSource.volume = 0.3f;
        audioSource.Play();
    }
}
