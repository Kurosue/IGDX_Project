using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float lerpTime = 1f;
    public bool isLerping = false;
    public AudioSource audioSource;
    private int EnemiesLeft;
    private float elapsedTime = 0f;

    void Start()
    {
        EnemiesLeft = 4;
        Enemy.OnEnemyKilled += EnemyKilled;
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.volume = 4f;
    }
    
    void Update()
    {   
        if (isLerping)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lerpTime;

            // Lerp between startPosition and endPosition
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            // Stop lerping when the end position is reached
            if (t >= 1f)
            {
                isLerping = false;
                Destroy(gameObject);
            }
        }
    }

    public void StartLerp()
    {
        elapsedTime = 0f;
        isLerping = true;
        audioSource.Play();
    }

    void EnemyKilled()
    {
        EnemiesLeft -= 1;
        Debug.Log("Musuh berkurang 1");

        if (EnemiesLeft == 0) {
            StartLerp();
        }
    }
}