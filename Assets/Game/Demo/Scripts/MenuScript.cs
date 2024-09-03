using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
