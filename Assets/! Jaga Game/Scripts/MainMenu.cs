using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Character Controller tests");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is now turned off");
    }
}
