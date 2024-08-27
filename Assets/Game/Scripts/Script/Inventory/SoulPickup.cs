using System;
using UnityEngine;

public class SoulPickup : MonoBehaviour
{
    public Soul soul; // The armor item that will be picked up
    public float pickupRadius = 3.0f; // Radius within which the player can pick up the item
    public KeyCode pickupKey = KeyCode.E; // Key to press for picking up the item

    private Transform player; // Reference to the player's transform
    private GSInventory playerInventory; // Reference to the player's inventory
    private bool playerFound = false;
    public static event Action OnRewardPickedUp;

    void Update()
    {
    // Try to find the player if it hasn't been found yet
        if (!playerFound)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player != null)
            {
                playerInventory = player.GetComponent<GSInventory>();
                if (playerInventory == null)
                {
                    Debug.LogError("Player does not have a GSInventory component.");
                }
                else
                {
                    playerFound = true; // Stop searching once the player is found
                }
            }
        }

        if (Vector3.Distance(player.position, transform.position) <= pickupRadius)
        {
            if (Input.GetKeyDown(pickupKey))
            {
                if (playerInventory != null && soul != null)
                {
                    playerInventory.PickSoul(soul);
                    Debug.Log("Picked up: " + soul.GetType().Name);
                    Destroy(gameObject); // Destroy the item in the scene after picking it up
                    OnRewardPickedUp?.Invoke();
                }
            }
        }
    }

    // Optional: Visualize the pickup radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
