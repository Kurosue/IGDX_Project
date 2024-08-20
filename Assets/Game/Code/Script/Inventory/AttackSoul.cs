using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoul : Soul
{
    void Awake()
    {
        Slot = GSInventory.SoulSlot.Attack; // Automatically assign the slot
    }

    public override void OnEquip()
    {
        base.OnEquip();
        Debug.Log("Attack equipped! Providing head protection.");
    }

    public override void OnDrop()
    {
        base.OnDrop();
        Debug.Log("Attack dropped! No more head protection.");
    }
}
