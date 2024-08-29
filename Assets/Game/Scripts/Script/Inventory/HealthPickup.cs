using System;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class HealthPickup : ButtonActivated {

    public static event Action OnRewardPickedUp;
    private Health playerHealth;

    public void PickingHealth()
    {
        playerHealth = LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<Health>();
        playerHealth.ReceiveHealth(50, gameObject);
        Debug.Log("Picked up health.");
        Destroy(gameObject); // Destroy the item in the scene after picking it up
        OnRewardPickedUp?.Invoke();
    }
}