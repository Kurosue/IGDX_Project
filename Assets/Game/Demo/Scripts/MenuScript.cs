using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Button pressed.");
    }

    public void StartEndless()
    {
        SceneManager.LoadScene("Endless");
        Debug.Log("Button pressed.");
    }

    public void MainMenu()
    {
        TopDownEngineEvent.Trigger(TopDownEngineEventTypes.UnPause, null);
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        TopDownEngineEvent.Trigger(TopDownEngineEventTypes.UnPause, null);
        Debug.Log("Game is resuming");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Button pressed.");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
