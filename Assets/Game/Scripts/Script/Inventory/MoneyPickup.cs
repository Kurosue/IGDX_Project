using System;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class MoneyPickup : ButtonActivated
{
    public static event Action OnRewardPickedUp;
    public static event Action OnMoneyPickedUp;

    public void PickingMoney()
    {
        Debug.Log("Picked up money.");
        Destroy(gameObject); // Destroy the item in the scene after picking it up
        OnMoneyPickedUp?.Invoke();
        OnRewardPickedUp?.Invoke();
    }
}