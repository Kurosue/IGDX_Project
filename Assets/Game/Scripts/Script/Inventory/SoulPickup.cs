using System;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class SoulPickup : ButtonActivated
{
    public Soul soul; // The armor item that will be picked up
    public bool DrawGizmo;

    private GSInventory playerInventory; // Reference to the player's inventory
    public static event Action OnRewardPickedUp;

    public void PickingSoul()
    {
        playerInventory = LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<GSInventory>();
        playerInventory.PickSoul(soul);
        Debug.Log("Picked up: " + soul.GetType().Name);
        Destroy(gameObject); // Destroy the item in the scene after picking it up
        OnRewardPickedUp?.Invoke();
    }
    void OnDrawGizmos()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null && meshFilter.sharedMesh != null && DrawGizmo == true)
        {
            Gizmos.color = Color.yellow; // Set the color of the outline
            Gizmos.DrawWireMesh(meshFilter.sharedMesh, transform.position, transform.rotation, transform.localScale);
        }

    }
}