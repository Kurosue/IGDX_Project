using System;
using UnityEngine;

public class GSInventory : MonoBehaviour
{
    // Armor slots
    private Soul attackSoulSlot;
    private Soul defenseSoulSlot;
    private Soul endureSoulSlot;

    // Enum to represent armor slots
    public enum SoulSlot
    {
        Attack,
        Defense,
        Endure
    }

    // PickArmor method to place the armor in the correct slot
    public void PickSoul(Soul item)
    {
        switch (item.Slot)
        {
            case SoulSlot.Attack:
                if (attackSoulSlot != null)
                {
                    attackSoulSlot.OnDrop();
                }
                attackSoulSlot = item;
                attackSoulSlot?.OnEquip();
                break;

            case SoulSlot.Defense:
                if (defenseSoulSlot != null)
                {
                    defenseSoulSlot.OnDrop();
                }
                defenseSoulSlot = item;
                defenseSoulSlot?.OnEquip();
                break;

            case SoulSlot.Endure:
                if (endureSoulSlot != null)
                {
                    endureSoulSlot.OnDrop(); // Drop the current leggings
                }
                endureSoulSlot = item;
                endureSoulSlot?.OnEquip(); // Equip the new leggings
                break;

            default:
                throw new ArgumentException("Invalid armor slot");
        }
    }
}