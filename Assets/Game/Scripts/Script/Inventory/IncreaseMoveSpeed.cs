using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;

[CreateAssetMenu(fileName = "SpeedSoul", menuName = "Soul/SpeedSoul")]
public class IncreaseMoveSpeed : Soul
{
    void Awake()
    {
        Slot = GSInventory.SoulSlot.Endure; // Automatically assign the slot
    }

    public override void OnEquip()
    {
        base.OnEquip();
        LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<CharacterMovement>().WalkSpeed += (float)0.5;
    }

    public override void OnDrop()
    {
        base.OnDrop();
        LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<CharacterMovement>().WalkSpeed -= (float)0.5;
    }
}