using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseSoul : Soul
{
    void Awake()
    {
        Slot = GSInventory.SoulSlot.Defense; // Automatically assign the slot
    }

    public override void OnEquip()
    {
        base.OnEquip();
        Debug.Log("Defense equipped! Providing chest protection.");
    }

    public override void OnDrop()
    {
        base.OnDrop();
        Debug.Log("Defense dropped! No more chest protection.");
    }
}
