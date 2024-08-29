using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;

[CreateAssetMenu(fileName = "HealthSoul", menuName = "Soul/HealthSoul")]
public class IncreaseHealth : Soul
{
    void Awake()
    {
        Slot = GSInventory.SoulSlot.Endure; // Automatically assign the slot
    }

    public override void OnEquip()
    {
        base.OnEquip();
        LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<Health>().MaximumHealth += 10;
    }

    public override void OnDrop()
    {
        base.OnDrop();
        LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<Health>().MaximumHealth -= 10;
    }
}
