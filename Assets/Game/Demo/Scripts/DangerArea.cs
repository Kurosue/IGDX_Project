using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DangerArea : MonoBehaviour
{
    public static event Action OnAreaEntered;

    void OnTriggerEnter(Collider other) {
        // Check if the object colliding is the player
        if (other.CompareTag("Player")) {
            // Invoke the event if a player enters the DangerArea
            OnAreaEntered?.Invoke();
            Destroy(gameObject);
        }
    }
    
}