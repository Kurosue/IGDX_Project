using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;

namespace MoreMountains.TopDownEngine
{	
	public class Progress 
	{
		public PermanentProgress PermanentProgress;
		public DungeonProgress DungeonProgress;
	}

	public class PermanentProgress
	{
		// PERMANENT PROGRESS //
		public int Reputation;

		public int UndistilledKnowledge;

		public int Gift; 
		public bool TwinKnivesUnlocked;
		public bool MaxHPPlus20;
		public bool SoulSlotPlus1;
		public bool ManaPlus1;
		// public NPC[] NPCList;
		//					//
		public bool IntroLevelCleared;
		public bool InDungeon;
	}

	public class DungeonProgress
	{
		// DUNGEON PROGRESS // 
		// public Artifact[] ArtifactList;
		public int HP;
		public bool CurrentWeapon;
		// public Artifact[] CurrentArtifact
		public int CurrentRoomLayout;
		public int CurrentRoomNumber;
		public bool isCleared;
		public int RoomReward;
		public int RewardChoice1;
		public int RewardChoice2;
		//					//		
	}
	
	public class ProgressManager : MMSingleton<ProgressManager>, MMEventListener<MMGameEvent>
	{
		
		// PERMANENT PROGRESS //
		public Progress progress;


		[MMInspectorButton("CreateSaveGame")]
		/// A test button to test creating the save file
		public bool CreateSaveGameBtn;

		protected const string _saveFolderName = "GodslayerProgressData";
		protected const string _saveFileName = "Progress.data";
		
		/// <summary>
		/// Statics initialization to support enter play modes
		/// </summary>
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		protected static void InitializeStatics()
		{
			_instance = null;
		}

		/// <summary>
		/// On awake, we load our progress and initialize our stars counter
		/// </summary>
		protected override void Awake()
		{
			base.Awake ();
			LoadSavedProgress ();
		}

		/// <summary>
		/// When a level is completed, we update our progress
		/// </summary>
		protected virtual void LevelComplete()
		{

		}

		/// <summary>
		/// Saves the progress to a file
		/// </summary>
		protected virtual void SaveProgress()
		{
			MMSaveLoadManager.Save(progress, _saveFileName, _saveFolderName);
		}

		/// <summary>
		/// A test method to create a test save file at any time from the inspector
		/// </summary>
		protected virtual void CreateSaveGame()
		{
			SaveProgress();
		}

		/// <summary>
		/// Loads the saved progress into memory
		/// </summary>
		protected virtual void LoadSavedProgress()
		{
			progress = (Progress)MMSaveLoadManager.Load(typeof(Progress), _saveFileName, _saveFolderName);
		}

		/// <summary>
		/// When we grab a level complete event, we update our status, and save our progress to file
		/// </summary>
		/// <param name="gameEvent">Game event.</param>

		/// <summary>
		/// This method describes what happens when the player loses all lives. In this case, we reset its progress and all lives will be reset.
		/// </summary>
		protected virtual void GameOver()
		{
			ResetProgress ();
		}

		/// <summary>
		/// A method used to remove all save files associated to progress
		/// </summary>
		public virtual void ResetProgress()
		{
			MMSaveLoadManager.DeleteSaveFolder (_saveFolderName);			
		}

		/// <summary>
		/// OnEnable, we start listening to events.
		/// </summary>
		protected virtual void OnEnable()
		{
			this.MMEventStartListening<MMGameEvent>();
		}

		/// <summary>
		/// OnDisable, we stop listening to events.
		/// </summary>
		protected virtual void OnDisable()
		{
			this.MMEventStopListening<MMGameEvent>();
		}

		public void OnMMEvent(MMGameEvent gameEvent)
		{
    		switch (gameEvent.EventName)
    		{	
				case "LevelComplete":
					LevelComplete ();
					SaveProgress ();
					break;
				case "GameOver":
					GameOver ();
					break;
				case "FreeingPrisoners":
					progress.PermanentProgress.Reputation += 2;
					break;
				case "GettingBook":
					progress.PermanentProgress.UndistilledKnowledge += 1;
					break;
				case "GettingGift":
					progress.PermanentProgress.Gift += 1;
					break;
				case "BuyingTwinKnives":
					progress.PermanentProgress.TwinKnivesUnlocked = true;
					break;
				case "UpgradeMaxHP":
					progress.PermanentProgress.MaxHPPlus20 = true;
					break;
				case "UpgradingSoulSlot":
					progress.PermanentProgress.SoulSlotPlus1 = true;
					break;
				case "UpgradingManaCapacity":
					progress.PermanentProgress.ManaPlus1 = true; 
					break;
				case "ClearingIntroLevel":
					progress.PermanentProgress.TwinKnivesUnlocked = true;
					break;
				default:
					// Handle unexpected cases if necessary
					break;
    		}
		}
	}
}