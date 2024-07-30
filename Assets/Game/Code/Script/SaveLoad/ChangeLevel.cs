using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{	
	/// <summary>
	/// Panggil tiap kali ganti level/area.
	/// </summary>
	public class DeadlineFinishLevel : FinishLevel 
	{
		/// <summary>
		/// Masuk ke level/area selanjutnya.
		/// </summary>
		public override void GoToNextLevel()
		{
			TopDownEngineEvent.Trigger(TopDownEngineEventTypes.LevelComplete, null);
			MMGameEvent.Trigger("Save");
			LevelManager.Instance.GotoLevel (LevelName);
		}	
	}
}
