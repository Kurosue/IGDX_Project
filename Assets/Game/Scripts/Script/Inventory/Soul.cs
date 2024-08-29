using UnityEngine;

public abstract class Soul : ScriptableObject
{
    // The slot this armor belongs to
    public GSInventory.SoulSlot Slot { get; protected set; }

    // Virtual method for picking/equipping the armor
    public virtual void OnEquip()
    {
        Debug.Log("Equipping armor: " + this.GetType().Name);
    }

    // Virtual method for dropping the armor
    public virtual void OnDrop()
    {
        Debug.Log("Dropping armor: " + this.GetType().Name);
    }
}