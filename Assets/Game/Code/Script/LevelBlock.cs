using UnityEngine;

public class LevelClearedListener : MonoBehaviour
{
    void OnEnable()
    {
        GSGameManager.OnLevelCleared += DestroySelfOnLevelCleared; // Subscribe to the LevelCleared event
    }

    void OnDestroy()
    {
        GSGameManager.OnLevelCleared -= DestroySelfOnLevelCleared; // Unsubscribe to avoid memory leaks
    }

    void DestroySelfOnLevelCleared()
    {
        Destroy(gameObject); // Destroy this GameObject when the level is cleared
    }
}