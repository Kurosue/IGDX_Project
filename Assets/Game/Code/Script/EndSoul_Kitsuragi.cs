using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using System;


	[CreateAssetMenu(fileName = "Kitsuragi", menuName = "Equipment/Souls/Kitsuragi", order = 2)]
	[Serializable]
	/// <summary>
	/// Demo class for an example armor item
	/// </summary>
	public class Kitsuragi : InventoryItem 
	{
		
		/// <summary>
		/// What happens when the armor is equipped
		/// </summary>
		public override bool Pick(string playerID)
		{
			base.Pick(playerID);
			/// health = TargetInventory(playerID).TargetTransform.GetComponent<Health>();
			LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<Health>().MaximumHealth += 10;
			Debug.Log("Health increaed by 10.");
			return true;
		}	

		/// <summary>
		/// What happens when the armor is unequipped
		/// </summary>
		public override bool Drop(string playerID)
		{
			base.Drop(playerID);
			LevelManager.Instance.Players[0].gameObject.MMGetComponentNoAlloc<Health>().MaximumHealth += 10;
			return true;
		}		
	}

