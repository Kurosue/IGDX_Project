using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndureSoul : Soul
{
    void Awake()
    {
        Slot = GSInventory.SoulSlot.Endure; // Automatically assign the slot
    }

    public override void OnEquip()
    {
        base.OnEquip();
        Debug.Log("Endure equipped! Providing leg protection.");
    }

    public override void OnDrop()
    {
        base.OnDrop();
        Debug.Log("Endure dropped! No more leg protection.");
    }
}